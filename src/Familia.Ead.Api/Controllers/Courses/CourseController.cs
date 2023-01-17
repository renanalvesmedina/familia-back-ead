using Familia.Ead.Api.Controllers.Courses.Inputs;
using Familia.Ead.Application.Requests.Courses.CreateCourse;
using Familia.Ead.Application.Requests.Courses.GetCourse;
using Familia.Ead.Application.Requests.Courses.SearchCourses;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Courses
{
    /// <summary>
    /// Course Operations
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : SuperApiController
    {
        /// <summary>
        /// Create a new course
        /// </summary>
        /// <param name="input">Course Data</param>
        /// <returns>Course Id</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_COURSE, ClaimConstants.ACTION_CREATE)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateCourse(CreateCourseInput input)
        {
            var request = new CreateCourseRequest
            {
                CourseName = input.CourseName,
                Description = input.Description,
            };

            var result = await Send(request);

            return Created(result);
        }

        /// <summary>
        /// Search all courses
        /// </summary>
        /// <returns>Return list of courses</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_COURSE, ClaimConstants.ACTION_VIEW)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SearchCoursesResponse>>> SearchCourses([FromRoute] bool isEnabled = true)
        {
            var request = new SearchCoursesRequest
            {
                IsEnabled = isEnabled
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get course details
        /// </summary>
        /// <returns>Return details of course</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_COURSE, ClaimConstants.ACTION_VIEW)]
        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCourseResponse>> GetCourse([FromQuery] Guid courseId)
        {
            var request = new GetCourseRequest
            {
                CourseId = courseId
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
