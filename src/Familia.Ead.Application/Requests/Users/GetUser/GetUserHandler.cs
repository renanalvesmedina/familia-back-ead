using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Users.GetUser
{
    public class GetUserHandler : Handler<GetUserRequest, GetUserResponse>
    {
        private readonly UserManager<User> _userManager;

        public GetUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundUser);

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = new GetUserResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Gender = user.Sexo,
                PhotoUri = user.ProfilePictureUri,
                Profiles = userRoles
            };

            return Success(result);
        }
    }
}
