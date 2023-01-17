using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.SearchMyClasses
{
    public class SearchMyClassesRequest : Request<IEnumerable<SearchMyClassesResponse>>
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
