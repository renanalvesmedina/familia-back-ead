using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Domain.Entities
{
    public class StudentHistory
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        [Required]
        public DateTime ViewingDate { get; set; }
    }
}
