using Familia.Ead.Application.Requests.Authentication.GenerateToken;
using Familia.Ead.Application.Requests.Authentication.RegisterLogin;
using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Familia.Ead.Application.Requests.Authentication.Authenticate
{
    public class AuthenticationHandler : Handler<AuthenticationRequest, AuthenticationResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        
        public AuthenticationHandler(UserManager<User> userManager, IMediator mediator, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _mediator = mediator;
            _signInManager = signInManager;
        }

        public override async Task<Result<AuthenticationResponse>> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var signin = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (!signin.Succeeded)
            {
                if (signin.IsLockedOut)
                    return BusinessRuleViolated(ErrorCatalog.Authentication.LockoutUser);
                else if (signin.IsNotAllowed)
                    return BusinessRuleViolated(ErrorCatalog.Authentication.NotAllowedUser);
                else
                    return NotFound(ErrorCatalog.Authentication.AuthenticateError);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Any())
                return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundRoles);

            var claims = await _userManager.GetClaimsAsync(user);

            var tokenRequest = new GenerateTokenRequest
            {
                UserId = user.Id,
                Roles = roles,
                Claims = claims
            };

            var tokenResponse = await _mediator.Send(tokenRequest, cancellationToken);

            var result = new AuthenticationResponse
            {
                UserName = user.FullName,
                ProfilePicture = user.ProfilePictureUri,
                Token = tokenResponse.Value.Token,
                Expiration = tokenResponse.Value.Expiration
            };

            await _mediator.Send(new RegisterLoginRequest { UserId = user.Id }, cancellationToken);

            return Success(result);
        }
    }
}
