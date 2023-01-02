namespace Familia.Ead.Application.Requests.Me.GetMyCourses
{
    /// <summary>
    /// Return course data
    /// </summary>
    public class GetMyCoursesResponse
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCardUri { get; set; }
        public Guid LastClassAttendedId { get; set; }
    }
}
