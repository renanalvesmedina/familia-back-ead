using Microsoft.IdentityModel.Tokens;

namespace Familia.Ead.Domain.Entities.Authentication
{
    public class RoleConstants
    {
        public static readonly string ROLE_ADMIN = "Admin";
        public static readonly string ROLE_MANAGER = "Manager";
        public static readonly string ROLE_STUDENT = "Student";
    }

    public class ClaimConstants
    {
        public static readonly string FULL_MANAGER = "Full Manager";
        public static readonly string CREATE_MANAGER = "Create Manager";
        public static readonly string EDIT_MANAGER = "Edit Manager";
        public static readonly string DELETE_MANAGER = "Delete Manager";
        public static readonly string VIEW_MANAGER = "View Manager";

        public static readonly string FULL_STUDENT = "Full Student";
        public static readonly string CREATE_STUDENT = "Create Student";
        public static readonly string EDIT_STUDENT = "Edit Student";
        public static readonly string DELETE_STUDENT = "Delete Student";
        public static readonly string VIEW_STUDENT = "View Student";

        public static readonly string FULL_ENROLLMENT = "Full Enrollment";
        public static readonly string CREATE_ENROLLMENT = "Create Enrollment";
        public static readonly string EDIT_ENROLLMENT = "Edit Enrollment";
        public static readonly string DELETE_ENROLLMENT = "Delete Enrollment";
        public static readonly string VIEW_ENROLLMENT = "View Enrollment";

        public static readonly string FULL_COURSE = "Full Course";
        public static readonly string CREATE_COURSE = "Create Course";
        public static readonly string EDIT_COURSE = "Edit Course";
        public static readonly string DELETE_COURSE = "Delete Course";
        public static readonly string VIEW_COURSE = "View Course";

        public static readonly string FULL_CLASS = "Full Class";
        public static readonly string CREATE_CLASS = "Create Class";
        public static readonly string EDIT_CLASS = "Edit Class";
        public static readonly string DELETE_CLASS = "Delete Class";
        public static readonly string VIEW_CLASS = "View Class";
    }

    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public double Expiration { get; set; }
    }
}
