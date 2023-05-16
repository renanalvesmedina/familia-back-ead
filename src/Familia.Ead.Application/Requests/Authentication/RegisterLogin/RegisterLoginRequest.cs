using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Authentication.RegisterLogin
{
    public class RegisterLoginRequest : Request
    {
        public Guid UserId { get; set; }
    }
}
