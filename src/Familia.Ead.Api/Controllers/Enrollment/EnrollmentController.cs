using Familia.Ead.Api.Controllers.Enrollment.Inputs;
using Familia.Ead.Application.Requests.Enrollments.CreateEnrollment;
using Familia.Ead.Application.Requests.Enrollments.Unenroll;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Familia.Ead.Api.Controllers.Enrollment
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : SuperApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EnrollmentController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Create a new enrollment
        /// </summary>
        /// <param name="input">Enrollment Data</param>
        /// <returns></returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimConstants.ACTION_CREATE)]
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

        /// <summary>
        /// Remove enrollment
        /// </summary>
        /// <param name="input">Enrollment Data</param>
        /// <returns></returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimConstants.ACTION_EDIT)]
        [HttpPut("Unenroll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Unenroll([FromBody] UnenrollInput input)
        {
            var request = new UnenrollRequest
            {
                StudentId = input.UserId,
                CourseId = input.CourseId,
                UnenrollBy = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
