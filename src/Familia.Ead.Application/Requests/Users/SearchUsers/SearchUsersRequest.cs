using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Users.SearchUsers
{
    public class SearchUsersRequest : Request<IEnumerable<SearchUsersResponse>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
