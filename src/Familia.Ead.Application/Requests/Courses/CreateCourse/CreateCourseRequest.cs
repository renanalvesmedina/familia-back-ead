using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Courses.CreateCourse
{
    public class CreateCourseRequest : Request
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}
