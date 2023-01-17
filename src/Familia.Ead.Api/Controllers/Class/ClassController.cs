using Familia.Ead.Api.Controllers.Class.Inputs;
using Familia.Ead.Application.Requests.Classes.CreateClass;
using Familia.Ead.Application.Requests.Classes.GetClass;
using Familia.Ead.Application.Requests.Classes.SearchClasses;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Bootstrap.Attributes;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Familia.Ead.Api.Controllers.Class
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassController : SuperApiController
    {
        /// <summary>
        /// Create a new class
        /// </summary>
        /// <param name="input">Class Data</param>
        /// <returns></returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_CLASS, ClaimConstants.ACTION_CREATE)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateClass(CreateClassInput input)
        {
            var request = new CreateClassRequest
            {
                ClassName = input.className,
                CourseId = input.courseId,
                Video = input.video,
                Description = input.description
            };

            var result = await Send(request);

            return Created(result);
        }


        /// <summary>
        /// Search all class of course
        /// </summary>
        /// <param name="courseId">Course id to filter classes</param>
        /// <returns>Return list of classes</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_CLASS, ClaimConstants.ACTION_VIEW)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SearchClassesResponse>>> SearchClasses([FromQuery] Guid courseId)
        {
            var request = new SearchClassesRequest
            {
                CourseId = courseId
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get class details
        /// </summary>
        /// <param name="classId">Course id to filter classes</param>
        /// <returns>Return list of classes</returns>
        [ClaimsAuthorize(ClaimConstants.CLAIM_TYPE_CLASS, ClaimConstants.ACTION_VIEW)]
        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetClassResponse>> GetClass([FromQuery] Guid classId)
        {
            var request = new GetClassRequest
            {
                ClassId = classId
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
