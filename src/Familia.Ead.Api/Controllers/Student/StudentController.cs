using Familia.Ead.Application.Requests.Classes.SearchClasses;
using Familia.Ead.Application.Requests.Student.SearchStudentHistory;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Student
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : SuperApiController
    {
        /// <summary>
        /// Search all class of course
        /// </summary>
        /// <param name="studentId">Student id to filter classes</param>
        /// <returns>Return list of classes</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_STUDENT, ClaimConstants.ACTION_VIEW)]
        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SearchStudentHistoryResponse>>> SearchStudentHistory([FromQuery] Guid studentId)
        {
            var request = new SearchStudentHistoryRequest
            {
                StudentId = studentId
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
