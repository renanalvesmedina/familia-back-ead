using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Me.ResetMyPassword
{
    public class ResetMyPasswordHandler : Handler<ResetMyPasswordRequest>
    {
        private readonly UserManager<User> _userManager;

        public ResetMyPasswordHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(ResetMyPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetPassResult = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (!resetPassResult.Succeeded)
                return BusinessRuleViolated(ErrorCatalog.Authentication.ResetPasswordFailed);

            return Success();
        }
    }
}
