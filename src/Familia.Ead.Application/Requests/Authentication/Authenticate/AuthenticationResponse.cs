namespace Familia.Ead.Application.Requests.Authentication.Authenticate
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
