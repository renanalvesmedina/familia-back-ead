namespace Familia.Ead.Api.Controllers.Class.Inputs
{
    /// <summary>
    /// Create Class Data
    /// </summary>
    public class CreateClassInput
    {
        /// <summary>
        /// Name of Class
        /// </summary>
        public string className { get; set; }

        /// <summary>
        /// Id of course
        /// </summary>
        public Guid courseId { get; set; }
        
        /// <summary>
        /// Uri of video class
        /// </summary>
        public string video { get; set; }

        /// <summary>
        /// Description of class
        /// </summary>
        public string description { get; set; }
    }
}
