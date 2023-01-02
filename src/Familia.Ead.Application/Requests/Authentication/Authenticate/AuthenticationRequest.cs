using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Authentication.Authenticate
{
    public class AuthenticationRequest : Request<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
