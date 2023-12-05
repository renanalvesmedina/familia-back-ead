using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Courses.EditCourse
{
    public class EditCourseRequest : Request
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public DateTime ExamDate { get; set; }
        public string CardUri { get; set; }
        public bool IsEnabled { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
