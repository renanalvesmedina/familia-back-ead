using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Authentication.CreateUser
{
    public class CreateUserHandler : Handler<CreateUserRequest>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly AuthenticationContext _context;
        private readonly IValidators _validators;

        public CreateUserHandler(UserManager<User> userManager, IValidators validators, RoleManager<IdentityRole<Guid>> roleManager, AuthenticationContext context)
        {
            _userManager = userManager;
            _validators = validators;
            _roleManager = roleManager;
            _context = context;
        }

        public override async Task<Result> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            // Validações
            if (!_validators.IsValidEmail(request.Email))
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidEmail);

            if (request.FullName.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidUserName);

            if (!request.Sexo.Equals("M") && !request.Sexo.Equals("F"))
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidSexo);

            if (request.Phone.Length != 11)
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidPhone);

            if (!await _roleManager.RoleExistsAsync(request.Perfil))
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidRole);

            // Criar usuario
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                PhoneNumber = request.Phone,
                Sexo = request.Sexo,
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return BusinessRuleViolated(ErrorCatalog.Authentication.NotCreated(error.Description));
                }
            }

            // Adiciona a role de perfil do usuario
            var roleResult = await _userManager.AddToRoleAsync(user, request.Perfil);

            if(!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    return BusinessRuleViolated(ErrorCatalog.Authentication.NotCreated(error.Description));
                }
            }

            // Adiciona as claims do perfil Student
            var _claims = ClaimConstants.StudentClaims(user.Id);

            foreach (var claim in _claims)
            {
                await _context.UserClaims.AddAsync(claim, cancellationToken);
            };

            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
