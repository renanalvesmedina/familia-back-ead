using Familia.Ead.Domain.Entities;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentHistory> StudentHistories { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnrollmentMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new StudentHistoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
