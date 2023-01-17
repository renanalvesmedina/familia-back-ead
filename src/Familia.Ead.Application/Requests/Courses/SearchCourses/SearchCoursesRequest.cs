using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Courses.SearchCourses
{
    public class SearchCoursesRequest : Request<IEnumerable<SearchCoursesResponse>>
    {
        public bool IsEnabled { get; set; }
    }
}
