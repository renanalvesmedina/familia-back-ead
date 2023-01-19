using Familia.Ead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Familia.Ead.Infrastructure.Mappings
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(c => c.Id);

            builder
                .HasOne(x => x.Course)
                .WithMany(s => s.Classes)
                .HasForeignKey(z => z.CourseId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasIndex(x => new { x.CourseId });
            builder.HasIndex(x => new { x.OrderId });
        }
    }
}
