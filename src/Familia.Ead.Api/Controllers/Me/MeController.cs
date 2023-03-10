using Familia.Ead.Api.Controllers.Courses.Inputs;
using Familia.Ead.Api.Controllers.Me.Inputs;
using Familia.Ead.Application.Requests.Courses.CreateCourse;
using Familia.Ead.Application.Requests.Me.CreateHistoryStudent;
using Familia.Ead.Application.Requests.Me.GetMyCourses;
using Familia.Ead.Application.Requests.Me.SearchMyClasses;
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

        public MeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Search courses of student
        /// </summary>
        /// <returns>Return list of courses by user id</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_COURSE, ClaimConstants.ACTION_VIEW)]
        [HttpGet("courses")]
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


        /// <summary>
        /// Search all class of course
        /// </summary>
        /// <param name="courseId">Course id to filter classes</param>
        /// <returns>Return list of classes</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_CLASS, ClaimConstants.ACTION_VIEW)]
        [HttpGet("classes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SearchMyClassesResponse>>> SearchMyClasses([FromQuery] Guid courseId)
        {
            var request = new SearchMyClassesRequest
            {
                CourseId = courseId,
                UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };

            var result = await Send(request);

            return Ok(result);
        }


        /// <summary>
        /// Create a new course
        /// </summary>
        /// <param name="input">Course Data</param>
        /// <returns>Course Id</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_STUDENT, ClaimConstants.ACTION_CREATE)]
        [HttpPost("history/register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateHistoryStudent(CreateHistoryStudentInput input)
        {
            var request = new CreateHistoryStudentRequest
            {
                StudentId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
                CourseId = input.CourseId,
                ClassId = input.ClassId,
            };

            var result = await Send(request);

            return Created(result);
        }
    }
}
