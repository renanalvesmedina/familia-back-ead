namespace Familia.Ead.Application.Requests.Users.SearchUsers
{
    public class SearchUsersResponse
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhotoUri { get; set; }
        public IList<string> Profile { get; set; }
    }
}
