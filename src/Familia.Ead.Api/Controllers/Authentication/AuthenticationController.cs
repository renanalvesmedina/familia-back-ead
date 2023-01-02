using Familia.Ead.Api.Controllers.Authentication.Inputs;
using Familia.Ead.Application.Requests.Authentication.Authenticate;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : SuperApiController
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="input">Login Data</param>
        /// <returns>Return jwt token</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthenticationResponse>> Authentication(AuthenticationInput input)
        {
            var request = new AuthenticationRequest
            {
                Email = input.Email,
                Password = input.Password
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
