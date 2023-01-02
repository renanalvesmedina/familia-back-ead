namespace Familia.Ead.Api.Controllers.Courses.Inputs
{
    /// <summary>
    /// Create Course Data
    /// </summary>
    public class CreateCourseInput
    {
        /// <summary>
        /// Name of Course
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Description of course
        /// </summary>
        public string Description { get; set; }
    }
}
