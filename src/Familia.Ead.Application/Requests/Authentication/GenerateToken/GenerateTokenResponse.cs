namespace Familia.Ead.Application.Requests.Authentication.GenerateToken
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
