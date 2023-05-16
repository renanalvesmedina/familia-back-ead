using Familia.Ead.Application.Requests.Student.Models;

namespace Familia.Ead.Application.Requests.Student.SearchStudentHistory
{
    public class SearchStudentHistoryResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<StudentHistoryModel> History { get; set; }
    }
}
