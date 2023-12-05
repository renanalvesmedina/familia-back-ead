namespace Familia.Ead.Api.Controllers.Class.Inputs
{
    public class EditClassInput
    {
        /// <summary>
        /// Id of class
        /// </summary>
        public Guid ClassId { get; set; }
        /// <summary>
        /// Name of Class
        /// </summary>
        public string className { get; set; }

        /// <summary>
        /// Uri of video class
        /// </summary>
        public string video { get; set; }

        /// <summary>
        /// Description of class
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Order of class
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Link thumb da aula
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Data em que a aula deve ser lançada
        /// </summary>
        public DateTime LaunchDate { get; set; }
    }
}
