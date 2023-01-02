using Familia.Ead.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Infrastructure.DbContexts
{
    public class AuthenticationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_MANAGER, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_STUDENT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_ENROLLMENT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_COURSE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_CLASS, CreatedOn = DateTime.Now }
            );

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>() { Id = Guid.Parse("b4cec1b6-917b-421e-bf79-6491eb6a1cdd"), Name = RoleConstants.ROLE_ADMIN, NormalizedName = RoleConstants.ROLE_ADMIN.ToUpper() },
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = RoleConstants.ROLE_MANAGER, NormalizedName = RoleConstants.ROLE_MANAGER.ToUpper() },
                new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = RoleConstants.ROLE_STUDENT, NormalizedName = RoleConstants.ROLE_STUDENT.ToUpper() }
            );

            var adminUser = new User() 
            { 
                Id = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                UserName = "contato@igrejafamilia.net",
                NormalizedUserName = "contato@igrejafamilia.net".ToUpper(),
                Email = "contato@igrejafamilia.net",
                NormalizedEmail = "contato@igrejafamilia.net".ToUpper(),
                FullName = "Familia Ead Admin",
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = new PasswordHasher<User>().HashPassword(adminUser, "Familia@2022");

            modelBuilder.Entity<User>().HasData( adminUser );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), RoleId = Guid.Parse("b4cec1b6-917b-421e-bf79-6491eb6a1cdd") }
            );

            modelBuilder.Entity<IdentityUserClaim<Guid>>().HasData(
                new IdentityUserClaim<Guid>() { Id = 1, UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_MANAGER },
                new IdentityUserClaim<Guid>() { Id = 2, UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_STUDENT },
                new IdentityUserClaim<Guid>() { Id = 3, UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_ENROLLMENT },
                new IdentityUserClaim<Guid>() { Id = 4, UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_COURSE },
                new IdentityUserClaim<Guid>() { Id = 5, UserId = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"), ClaimType = RoleConstants.ROLE_ADMIN, ClaimValue = ClaimConstants.FULL_CLASS }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
