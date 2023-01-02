using Familia.Ead.Api.Controllers.Courses.Inputs;
using Familia.Ead.Application.Requests.Courses.CreateCourse;
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
    }
}
