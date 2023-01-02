using Familia.Ead.Application.Requests.Me.GetCourses;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Me
{
    /// <summary>
    /// User operations
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class MeController : SuperApiController
    {
        /// <summary>
        /// Search courses of student
        /// </summary>
        /// <returns>Return list of courses by user id</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GetCoursesResponse>>> GetCourses()
        {
            var request = new GetCoursesRequest
            {
                //To-Do
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6")
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
