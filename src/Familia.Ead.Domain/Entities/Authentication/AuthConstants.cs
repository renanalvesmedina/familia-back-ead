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
    }

    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
