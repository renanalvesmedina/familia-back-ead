namespace Familia.Ead.Api.Controllers.Enrollment.Inputs
{
    /// <summary>
    /// Create Enrollment Data
    /// </summary>
    public class CreateEnrollmentInput
    {
        /// <summary>
        /// User id of student
        /// </summary>
        public Guid StudentId { get; set; }
        /// <summary>
        /// Id of course
        /// </summary>
        public Guid CourseId { get; set; }
    }
}
