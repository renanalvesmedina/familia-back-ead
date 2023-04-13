using Lumini.Common.Mediator;
using Microsoft.AspNetCore.Http;

namespace Familia.Ead.Application.Requests.Me.UpdateMyAvatar
{
    public class UpdateMyAvatarRequest : Request
    {
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
