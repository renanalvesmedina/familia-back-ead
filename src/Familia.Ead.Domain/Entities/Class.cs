namespace Familia.Ead.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string Video { get; set; }
        public string Thumb { get; set; }
        public DateTime LaunchDate { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
