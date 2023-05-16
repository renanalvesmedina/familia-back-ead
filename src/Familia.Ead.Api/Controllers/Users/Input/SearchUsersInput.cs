namespace Familia.Ead.Api.Controllers.Users.Input
{
    /// <summary>
    /// Search Users Input filters
    /// </summary>
    public class SearchUsersInput
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
    }
}
