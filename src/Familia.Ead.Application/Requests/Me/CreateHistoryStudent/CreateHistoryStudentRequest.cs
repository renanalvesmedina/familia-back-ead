using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.CreateHistoryStudent
{
    public class CreateHistoryStudentRequest : Request
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid ClassId { get; set; }
    }
}
