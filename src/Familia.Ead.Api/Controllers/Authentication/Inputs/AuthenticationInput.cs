using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Api.Controllers.Authentication.Inputs
{
    /// <summary>
    /// Authentication Data
    /// </summary>
    public class AuthenticationInput
    {
        /// <summary>
        /// Email of login on platform
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
