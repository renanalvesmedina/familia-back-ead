using Familia.Ead.Api.Controllers.Users.Input;
using Familia.Ead.Application.Requests.Users.EditUser;
using Familia.Ead.Application.Requests.Users.GetUser;
using Familia.Ead.Application.Requests.Users.SearchUsers;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Users
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : SuperApiController
    {
        /// <summary>
        /// Search all users
        /// </summary>
        /// <returns>Return list of users</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_MANAGER, ClaimConstants.ACTION_VIEW)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SearchUsersResponse>>> SearchUsers(int start = 0, int limit = 25)
        {
            var request = new SearchUsersRequest
            {
                Skip = start,
                Take = limit
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <returns>Return user data</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_MANAGER, ClaimConstants.ACTION_VIEW)]
        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromQuery] Guid UserId)
        {
            var request = new GetUserRequest
            {
                UserId = UserId
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Edit user
        /// </summary>
        /// <param name="UserId">User id</param>
        /// <param name="input">User Data</param>
        /// <returns></returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_MANAGER, ClaimConstants.ACTION_EDIT)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditUser([FromQuery] Guid UserId, [FromBody] EditUserInput input)
        {
            var request = new EditUserRequest
            {
                UserId = UserId,
                FullName = input.FullName,
                Phone = input.Phone,
                Gender = input.Gender,
                Profiles = input.Profiles
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
