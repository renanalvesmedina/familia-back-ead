using Lumini.Common.Mediator;
using System.Security.Claims;

namespace Familia.Ead.Application.Requests.Authentication.GenerateToken
{
    public class GenerateTokenRequest : Request<GenerateTokenResponse>
    {
        public Guid UserId { get; set; }
        public IList<string> Roles { get; set; }
        public IList<Claim> Claims { get; set; }
    }
}
