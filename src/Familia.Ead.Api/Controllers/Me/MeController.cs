using Familia.Ead.Api.Controllers.Me.Inputs;
using Familia.Ead.Application.Requests.Me.CreateHistoryStudent;
using Familia.Ead.Application.Requests.Me.EditMyProfile;
using Familia.Ead.Application.Requests.Me.GetMyCourses;
using Familia.Ead.Application.Requests.Me.GetMyProfile;
using Familia.Ead.Application.Requests.Me.ResetMyPassword;
using Familia.Ead.Application.Requests.Me.SearchMyClasses;
using Familia.Ead.Application.Requests.Me.UpdateMyAvatar;
using Lumini.Common.Model.Presenter.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        /// Get profile data
        /// </summary>
        /// <returns>Return data of student profile</returns>
        [HttpGet("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMyProfileResponse>> GetMyProfile()
        {
            var request = new GetMyProfileRequest
            {
                UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };

            var result = await Send(request);

            return Ok(result);
        }


        /// <summary>
        /// Edit student profile
        /// </summary>
        /// <returns></returns>
        [HttpPut("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditMyProfile([FromBody] EditMyProfileInput input)
        {
            var request = new EditMyProfileRequest
            {
                UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
                FullName = input.FullName,
                PhoneNumber = input.PhoneNumber,
                Sexo = input.Sexo
            };

            var result = await Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Search courses of student
        /// </summary>
        /// <returns>Return list of courses by user id</returns>
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


        /// <summary>
        /// Reset password of user
        /// </summary>
        /// <param name="input">The password reset data</param>
        /// <returns>Course Id</returns>
        [HttpPost("password/reset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ResetMyPassword(ResetMyPasswordInput input)
        {
            var request = new ResetMyPasswordRequest
            {
                UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword,
                ConfirmPassword = input.ConfirmPassword,
            };

            var result = await Send(request);

            return Ok(result);
        }


        /// <summary>
        /// Update profile avatar of user
        /// </summary>
        /// <param name="image">The image</param>
        /// <returns></returns>
        [HttpPut("profile/avatar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMyAvatar(IFormFile image)
        {
            var request = new UpdateMyAvatarRequest
            {
                UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value),
                Image = image
            };

            var result = await Send(request);

            return Ok(result);
        }
    }
}
