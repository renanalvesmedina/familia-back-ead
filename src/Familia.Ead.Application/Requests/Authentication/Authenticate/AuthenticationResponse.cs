namespace Familia.Ead.Application.Requests.Authentication.Authenticate
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
