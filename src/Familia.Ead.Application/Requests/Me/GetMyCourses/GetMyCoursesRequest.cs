using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.GetMyCourses
{
    public class GetMyCoursesRequest : Request<IEnumerable<GetMyCoursesResponse>>
    {
        public Guid UserId { get; set; }
    }
}
