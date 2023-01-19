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
            // Start Seed Authentication Data ====>>>

            // Create Claims
            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_CREATE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_EDIT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_VIEW, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_DELETE, CreatedOn = DateTime.Now },

                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_CREATE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_EDIT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_VIEW, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_DELETE, CreatedOn = DateTime.Now },

                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_CREATE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_EDIT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_VIEW, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_DELETE, CreatedOn = DateTime.Now },

                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_CREATE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_EDIT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_VIEW, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_DELETE, CreatedOn = DateTime.Now },

                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_CREATE, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_EDIT, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_VIEW, CreatedOn = DateTime.Now },
                new UserClaim() { Id = Guid.NewGuid(), ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_DELETE, CreatedOn = DateTime.Now }
            );

            // Create Roles
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>() { Id = Guid.Parse("b4cec1b6-917b-421e-bf79-6491eb6a1cdd"), Name = RoleConstants.ROLE_ADMIN, NormalizedName = RoleConstants.ROLE_ADMIN.ToUpper() },
                new IdentityRole<Guid>() { Id = Guid.Parse("7fb0e422-9a6d-4a87-a925-9815906e6475"), Name = RoleConstants.ROLE_MANAGER, NormalizedName = RoleConstants.ROLE_MANAGER.ToUpper() },
                new IdentityRole<Guid>() { Id = Guid.Parse("73b8e1eb-845f-4d03-a81f-8c634b633277"), Name = RoleConstants.ROLE_STUDENT, NormalizedName = RoleConstants.ROLE_STUDENT.ToUpper() }
            );

            // Create User Admin
            var adminUser = new User() 
            { 
                Id = Guid.Parse("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                UserName = "contato@igrejafamilia.net.br",
                NormalizedUserName = "contato@igrejafamilia.net.br".ToUpper(),
                Email = "contato@igrejafamilia.net.br",
                NormalizedEmail = "contato@igrejafamilia.net.br".ToUpper(),
                FullName = "Familia Ead Admin",
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = new PasswordHasher<User>().HashPassword(adminUser, "Familia@2022");
            modelBuilder.Entity<User>().HasData( adminUser );

            //Add Role Admin to Admin User
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { UserId = adminUser.Id, RoleId = Guid.Parse("b4cec1b6-917b-421e-bf79-6491eb6a1cdd") }
            );

            //Add All Claims to Admin User
            modelBuilder.Entity<IdentityUserClaim<Guid>>().HasData(
                new IdentityUserClaim<Guid>() { Id = 1, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_CREATE },
                new IdentityUserClaim<Guid>() { Id = 2, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_EDIT },
                new IdentityUserClaim<Guid>() { Id = 3, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_DELETE },
                new IdentityUserClaim<Guid>() { Id = 4, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_MANAGER, ClaimValue = ClaimConstants.ACTION_VIEW },

                new IdentityUserClaim<Guid>() { Id = 5, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_CREATE },
                new IdentityUserClaim<Guid>() { Id = 6, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_EDIT },
                new IdentityUserClaim<Guid>() { Id = 7, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_DELETE },
                new IdentityUserClaim<Guid>() { Id = 8, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_STUDENT, ClaimValue = ClaimConstants.ACTION_VIEW },

                new IdentityUserClaim<Guid>() { Id = 9, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_CREATE },
                new IdentityUserClaim<Guid>() { Id = 10, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_EDIT },
                new IdentityUserClaim<Guid>() { Id = 11, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_DELETE },
                new IdentityUserClaim<Guid>() { Id = 12, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_ENROLLMENT, ClaimValue = ClaimConstants.ACTION_VIEW },

                new IdentityUserClaim<Guid>() { Id = 13, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_CREATE },
                new IdentityUserClaim<Guid>() { Id = 14, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_EDIT },
                new IdentityUserClaim<Guid>() { Id = 15, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_DELETE },
                new IdentityUserClaim<Guid>() { Id = 16, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_COURSE, ClaimValue = ClaimConstants.ACTION_VIEW },

                new IdentityUserClaim<Guid>() { Id = 17, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_CREATE },
                new IdentityUserClaim<Guid>() { Id = 18, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_EDIT },
                new IdentityUserClaim<Guid>() { Id = 19, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_DELETE },
                new IdentityUserClaim<Guid>() { Id = 20, UserId = adminUser.Id, ClaimType = ClaimConstants.CLAIM_TYPE_CLASS, ClaimValue = ClaimConstants.ACTION_VIEW }
            );

            base.OnModelCreating(modelBuilder);

            // <<<==== Finish Seed Authentication Data
        }
    }
}
