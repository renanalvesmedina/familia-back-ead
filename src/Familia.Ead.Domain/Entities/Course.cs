namespace Familia.Ead.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string CardUri { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual IList<Class> Classes { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }
    }
}
