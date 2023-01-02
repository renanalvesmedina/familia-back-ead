using Familia.Ead.Api.Controllers.Enrollment.Inputs;
using Familia.Ead.Application.Requests.Enrollments.CreateEnrollment;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Enrollment
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EnrollmentController : SuperApiController
    {
        /// <summary>
        /// Create a new enrollment
        /// </summary>
        /// <param name="input">Enrollment Data</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateEnrollment(CreateEnrollmentInput input)
        {
            var request = new CreateEnrollmentRequest
            {
                StudentId = input.StudentId,
                CourseId = input.CourseId
            };
            
            var result = await Send(request);

            return Created(result);
        }
    }
}
