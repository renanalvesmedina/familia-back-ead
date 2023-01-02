using Familia.Ead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Familia.Ead.Infrastructure.Mappings
{
    public class StudentHistoryMap : IEntityTypeConfiguration<StudentHistory>
    {
        public void Configure(EntityTypeBuilder<StudentHistory> builder)
        {
            builder.ToTable("StudentHistories");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.StudentId);
            builder.HasIndex(c => c.CourseId);
            builder.HasIndex(c => c.ClassId);
        }
    }
}
