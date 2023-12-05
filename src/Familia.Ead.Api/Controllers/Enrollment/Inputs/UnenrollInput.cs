namespace Familia.Ead.Api.Controllers.Enrollment.Inputs
{
    /// <summary>
    /// Dados para desmatricular um aluno
    /// </summary>
    public class UnenrollInput
    {
        /// <summary>
        /// Id do aluno
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Id do curso
        /// </summary>
        public Guid CourseId { get; set; }
    }
}
