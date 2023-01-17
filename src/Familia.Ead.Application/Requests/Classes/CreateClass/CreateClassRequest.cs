using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Classes.CreateClass
{
    public class CreateClassRequest : Request
    {
        public string ClassName { get; set; }
        public Guid CourseId { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
    }
}
