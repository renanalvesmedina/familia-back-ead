using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Api.Controllers.Me.Inputs
{
    /// <summary>
    /// Edit profile
    /// </summary>
    public class EditMyProfileInput
    {
        /// <summary>
        /// Nome completo do usuario
        /// </summary>
        [Required]
        public string FullName { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Sexo: M - Masculino | F - Feminino
        /// </summary>
        [Required]
        public string Sexo { get; set; }
    }
}
