using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.GetMyProfile
{
    public class GetMyProfileRequest : Request<GetMyProfileResponse>
    {
        public Guid UserId { get; set; }
    }
}
