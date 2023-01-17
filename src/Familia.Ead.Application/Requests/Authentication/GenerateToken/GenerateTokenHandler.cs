using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Familia.Ead.Application.Requests.Authentication.GenerateToken
{
    public class GenerateTokenHandler : Handler<GenerateTokenRequest, GenerateTokenResponse>
    {
        private readonly JwtOptions _jwtOptions;

        public GenerateTokenHandler(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public override Task<Result<GenerateTokenResponse>> Handle(GenerateTokenRequest request, CancellationToken cancellationToken)
        {
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Sub, request.UserId.ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in request.Roles)
                request.Claims.Add(new Claim("role", role));

            var expirationDate = DateTime.Now.AddHours(2);


            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: request.Claims,
                expires: expirationDate,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            var result = new GenerateTokenResponse()
            {
                Token = token,
                Expiration = expirationDate
            };

            return Success(result);
        }
    }
}
