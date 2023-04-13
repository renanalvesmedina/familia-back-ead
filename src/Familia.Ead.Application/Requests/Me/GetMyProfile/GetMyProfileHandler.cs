using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.GetMyProfile
{
    public class GetMyProfileHandler : Handler<GetMyProfileRequest, GetMyProfileResponse>
    {
        private readonly UserManager<User> _userManager;

        public GetMyProfileHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result<GetMyProfileResponse>> Handle(GetMyProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
                return NotFound(ErrorCatalog.Authentication.NotFoundUser);

            var result = new GetMyProfileResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                Sexo = user.Sexo,
                Telefone = user.PhoneNumber,
                ProfilePicture = user.ProfilePictureUri,
            };

            return Success(result);
        }
    }
}
