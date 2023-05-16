using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Student.SearchStudentHistory
{
    public class SearchStudentHistoryRequest : Request<IEnumerable<SearchStudentHistoryResponse>>
    {
        public Guid StudentId { get; set; }
    }
}
