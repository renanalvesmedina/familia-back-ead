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
        public string FullName { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Sexo: M - Masculino | F - Feminino
        /// </summary>
        public string Sexo { get; set; }
    }
}
