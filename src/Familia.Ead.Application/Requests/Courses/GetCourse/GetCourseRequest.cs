using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Courses.GetCourse
{
    public class GetCourseRequest : Request<GetCourseResponse>
    {
        public Guid CourseId { get; set; }
    }
}
