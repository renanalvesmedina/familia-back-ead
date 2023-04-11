using Familia.Ead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Familia.Ead.Infrastructure.Mappings
{
    public class EnrollmentMap : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.StudentId);

            builder
                .HasOne(x => x.Course)
                .WithMany(s => s.Enrollments)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(z => new { z.CourseId });
        }
    }
}
