namespace Familia.Ead.Domain.Entities
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
