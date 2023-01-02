using Familia.Ead.Api.Controllers.Courses.Inputs;
using Familia.Ead.Application.Requests.Courses.CreateCourse;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Courses
{
    /// <summary>
    /// Course Operations
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class CourseController : SuperApiController
    {
        /// <summary>
        /// Create a new course
        /// </summary>
        /// <param name="input">Course Data</param>
        /// <returns>Course Id</returns>
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
