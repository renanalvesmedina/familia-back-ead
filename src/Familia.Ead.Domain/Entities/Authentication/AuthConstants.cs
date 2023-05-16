using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Familia.Ead.Domain.Entities.Authentication
{
    public static class RoleConstants
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_MANAGER = "Manager";
        public const string ROLE_STUDENT = "Student";
    }

    public static class ClaimConstants
    {
        public const string CLAIM_TYPE_MANAGER = "Manager";
        public const string CLAIM_TYPE_STUDENT = "Student";
        public const string CLAIM_TYPE_ENROLLMENT = "Enrollment";
        public const string CLAIM_TYPE_COURSE = "Course";
        public const string CLAIM_TYPE_CLASS = "Class";

        public const string ACTION_CREATE = "Create";
        public const string ACTION_EDIT = "Edit";
        public const string ACTION_DELETE = "Delete";
        public const string ACTION_VIEW = "View";

        public static IEnumerable<IdentityUserClaim<Guid>> AdminClaims(Guid userId)
        {
            return new List<IdentityUserClaim<Guid>>
            {
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_MANAGER,
                    ClaimValue = ACTION_CREATE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_MANAGER,
                    ClaimValue = ACTION_EDIT
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_MANAGER,
                    ClaimValue = ACTION_DELETE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_MANAGER,
                    ClaimValue = ACTION_VIEW
                },

                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_STUDENT,
                    ClaimValue = ACTION_CREATE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_STUDENT,
                    ClaimValue = ACTION_EDIT
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_STUDENT,
                    ClaimValue = ACTION_DELETE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_STUDENT,
                    ClaimValue = ACTION_VIEW
                },

                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_ENROLLMENT,
                    ClaimValue = ACTION_CREATE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_ENROLLMENT,
                    ClaimValue = ACTION_EDIT
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_ENROLLMENT,
                    ClaimValue = ACTION_DELETE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_ENROLLMENT,
                    ClaimValue = ACTION_VIEW
                },

                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_COURSE,
                    ClaimValue = ACTION_CREATE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_COURSE,
                    ClaimValue = ACTION_EDIT
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_COURSE,
                    ClaimValue = ACTION_DELETE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_COURSE,
                    ClaimValue = ACTION_VIEW
                },

                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_CLASS,
                    ClaimValue = ACTION_CREATE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_CLASS,
                    ClaimValue = ACTION_EDIT
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_CLASS,
                    ClaimValue = ACTION_DELETE
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_CLASS,
                    ClaimValue = ACTION_VIEW
                },
            };
        }

        public static IEnumerable<IdentityUserClaim<Guid>> StudentClaims(Guid userId)
        {
            return new List<IdentityUserClaim<Guid>>
            {
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_COURSE,
                    ClaimValue = ACTION_VIEW
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_CLASS,
                    ClaimValue = ACTION_VIEW
                },
                new IdentityUserClaim<Guid>()
                {
                    UserId = userId,
                    ClaimType = CLAIM_TYPE_STUDENT,
                    ClaimValue = ACTION_VIEW
                }
            };
        }
    }

    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
