using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Enrollments.Unenroll
{
    public class UnenrollRequest : Request
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid UnenrollBy { get; set; }
    }
}
