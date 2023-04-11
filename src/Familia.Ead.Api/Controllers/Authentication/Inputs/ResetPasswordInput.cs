using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Api.Controllers.Authentication.Inputs
{
    /// <summary>
    /// Reset Password Input
    /// </summary>
    public class ResetPasswordInput
    {
        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// New password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Token of forgot password
        /// </summary>
        public string Token { get; set; }
    }
}
