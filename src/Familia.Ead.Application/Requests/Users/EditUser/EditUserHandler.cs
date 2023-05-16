using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Users.EditUser
{
    public class EditUserHandler : Handler<EditUserRequest>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthenticationContext _authContext;

        public EditUserHandler(UserManager<User> userManager, AuthenticationContext authContext)
        {
            _userManager = userManager;
            _authContext = authContext;
        }

        public override async Task<Result> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            // Validations
            if (request.FullName.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidUserName);

            if (!request.Gender.Equals("M") && !request.Gender.Equals("F"))
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidSexo);

            if (request.Phone.Length != 11)
                return BusinessRuleViolated(ErrorCatalog.Authentication.InvalidPhone);


            // Find user in db
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundUser);

            // Update user properties
            user.FullName = request.FullName;
            user.PhoneNumber = request.Phone;
            user.Sexo = request.Gender;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                    return BusinessRuleViolated(ErrorCatalog.User.NotEdited(error.Description));
            }

            // Update roles on user
            if (request.Profiles.Contains(RoleConstants.ROLE_ADMIN) && !await _userManager.IsInRoleAsync(user, RoleConstants.ROLE_ADMIN))
            {
                var roleResult = await _userManager.AddToRoleAsync(user, RoleConstants.ROLE_ADMIN);

                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                        return BusinessRuleViolated(ErrorCatalog.User.NotEdited(error.Description));
                }

                var claims = ClaimConstants.AdminClaims(user.Id);

                foreach (var claim in claims)
                    await _authContext.UserClaims.AddAsync(claim, cancellationToken);
            }


            if (request.Profiles.Contains(RoleConstants.ROLE_STUDENT) && !await _userManager.IsInRoleAsync(user, RoleConstants.ROLE_STUDENT))
            {
                var roleResult = await _userManager.AddToRoleAsync(user, RoleConstants.ROLE_STUDENT);

                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                        return BusinessRuleViolated(ErrorCatalog.User.NotEdited(error.Description));
                }

                var claims = ClaimConstants.StudentClaims(user.Id);

                foreach (var claim in claims)
                    await _authContext.UserClaims.AddAsync(claim, cancellationToken);
            }

            return Success();
        }
    }
}
