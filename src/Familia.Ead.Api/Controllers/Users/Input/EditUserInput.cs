namespace Familia.Ead.Api.Controllers.Users.Input
{
    /// <summary>
    /// Edit User
    /// </summary>
    public class EditUserInput
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Genero
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Lista de Perfis: Admin, Manager, Student
        /// </summary>
        public IList<string> Profiles { get; set; }
    }
}
