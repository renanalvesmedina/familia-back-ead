using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Classes.SearchClasses
{
    public class SearchClassesRequest : Request<IEnumerable<SearchClassesResponse>>
    {
        public Guid CourseId { get; set; }
    }
}
