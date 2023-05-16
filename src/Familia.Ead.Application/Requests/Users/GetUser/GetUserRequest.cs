using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Users.GetUser
{
    public class GetUserRequest : Request<GetUserResponse>
    {
        public Guid UserId { get; set; }
    }
}
