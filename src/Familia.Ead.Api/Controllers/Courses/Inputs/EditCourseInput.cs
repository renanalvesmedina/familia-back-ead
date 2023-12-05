namespace Familia.Ead.Api.Controllers.Courses.Inputs
{
    /// <summary>
    /// Edit Course
    /// </summary>
    public class EditCourseInput
    {
        /// <summary>
        /// Course Id
        /// </summary>
        public Guid CourseId { get; set; }
        /// <summary>
        /// Name of Course
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// Description of course
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Class quantity
        /// </summary>
        public int Workload { get; set; }
        /// <summary>
        /// Date of finish exam
        /// </summary>
        public DateTime ExamDate { get; set; }
        /// <summary>
        /// Uri of card image
        /// </summary>
        public string CardUri { get; set; }
        /// <summary>
        /// Status of course
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
