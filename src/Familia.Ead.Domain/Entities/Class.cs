﻿namespace Familia.Ead.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string VideoUri { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
