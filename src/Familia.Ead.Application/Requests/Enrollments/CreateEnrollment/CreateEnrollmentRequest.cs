using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Enrollments.CreateEnrollment
{
    public class CreateEnrollmentRequest : Request
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
