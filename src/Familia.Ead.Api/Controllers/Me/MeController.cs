using Familia.Ead.Application.Requests.Me.GetMyCourses;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Familia.Ead.Api.Controllers.Me
{
    /// <summary>
    /// User operations
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class MeController : SuperApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MeController(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        /// <summary>
        /// Search courses of student
        /// </summary>
        /// <returns>Return list of courses by user id</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_COURSE, ClaimConstants.ACTION_VIEW)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GetMyCoursesResponse>>> GetMyCourses()
        {
            var request = new GetMyCoursesRequest
            {
                UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
