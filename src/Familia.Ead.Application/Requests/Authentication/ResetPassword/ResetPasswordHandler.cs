using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Authentication.ResetPassword
{
    public class ResetPasswordHandler : Handler<ResetPasswordRequest>
    {
        private readonly UserManager<User> _userManager;

        public ResetPasswordHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return NotFound(ErrorCatalog.Authentication.NotFoundUser);

            // CÓDIGO TEMPORÁRIO. TO-DO: IMPLANTAR FEATURE DE ESQUECEU SENHA COM ENVIO DO TOKEN POR EMAIL.
            request.Token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetPassResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

            if (!resetPassResult.Succeeded)
                return BusinessRuleViolated(ErrorCatalog.Authentication.ResetPasswordFailed);

            return Success();
        }
    }
}
