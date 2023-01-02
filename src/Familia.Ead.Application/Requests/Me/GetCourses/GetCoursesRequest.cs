using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.GetCourses
{
    public class GetCoursesRequest : Request<IEnumerable<GetCoursesResponse>>
    {
        public Guid UserId { get; set; }
    }
}
