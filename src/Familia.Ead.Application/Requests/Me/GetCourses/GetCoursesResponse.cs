namespace Familia.Ead.Application.Requests.Me.GetCourses
{
    /// <summary>
    /// Return course data
    /// </summary>
    public class GetCoursesResponse
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCardUri { get; set; }
        public Guid LastClassAttendedId { get; set; }
    }
}
