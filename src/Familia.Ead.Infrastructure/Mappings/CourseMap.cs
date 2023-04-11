using Familia.Ead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Familia.Ead.Infrastructure.Mappings
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            builder
                .HasMany(c => c.Classes)
                .WithOne(z => z.Course);

            builder
                .HasMany(c => c.Enrollments)
                .WithOne(z => z.Course);
        }
    }
}
