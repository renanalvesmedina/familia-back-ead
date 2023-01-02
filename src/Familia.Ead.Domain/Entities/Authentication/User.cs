using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Familia.Ead.Domain.Entities.Authentication
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string FullName { get; set; }
        public string ProfilePictureUri { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
