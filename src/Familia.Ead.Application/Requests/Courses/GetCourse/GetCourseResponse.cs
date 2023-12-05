namespace Familia.Ead.Application.Requests.Courses.GetCourse
{
    public class GetCourseResponse
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string CourseCardUri { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
