namespace Familia.Ead.Application
{
    public class CourseEnrollmentsModel
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid LastClassAttendeceId { get; set; }
        public int TotalCourseClasses { get; set; }
        public int TotalCompletedClasses { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
