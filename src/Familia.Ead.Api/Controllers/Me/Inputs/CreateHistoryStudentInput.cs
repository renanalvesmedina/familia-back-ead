namespace Familia.Ead.Api.Controllers.Me.Inputs
{
    /// <summary>
    /// History Student
    /// </summary>
    public class CreateHistoryStudentInput
    {
        /// <summary>
        /// Id of Course
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Id of Class
        /// </summary>
        public Guid ClassId { get; set; }
    }
}
