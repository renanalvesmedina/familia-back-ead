using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Authentication.ResetPassword
{
    public class ResetPasswordRequest : Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
