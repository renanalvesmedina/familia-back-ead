using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Api.Controllers.Me.Inputs
{
    /// <summary>
    /// Reset my password
    /// </summary>
    public class ResetMyPasswordInput
    {
        /// <summary>
        /// Senha atual
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Nova senha
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Confirme a nova senha
        /// </summary>
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}
