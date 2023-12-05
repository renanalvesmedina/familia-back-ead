using Familia.Ead.Api.Controllers.Authentication.Inputs;
using Familia.Ead.Application.Requests.Authentication.Authenticate;
using Familia.Ead.Application.Requests.Authentication.CreateUser;
using Familia.Ead.Application.Requests.Authentication.ResetPassword;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
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
        /// <returns>Return token</returns>
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


        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="input">The User data</param>
        /// <returns>The id of the user created</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_MANAGER, ClaimConstants.ACTION_CREATE)]
        [Authorize]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Create(CreateUserInput input)
        {
            var request = new CreateUserRequest
            {
                FullName = input.FullName,
                Email = input.Email,
                Password = input.Password,
                Phone = input.Phone,
                Sexo = input.Sexo,
                Perfil = input.Perfil
            };

            var result = await Send(request);

            return Created(result);
        }


        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="input">The user data</param>
        /// <returns></returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_STUDENT, ClaimConstants.ACTION_EDIT)]
        [HttpPost("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ResetPassword(ResetPasswordInput input)
        {
            var request = new ResetPasswordRequest
            {
                Email = input.Email,
                Password = input.Password,
                Token = input.Token
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
