using System.ComponentModel.DataAnnotations.Schema;

namespace Familia.Ead.Domain.Entities
{
    public class ActivityHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; }
        public DateTime ActivityAt { get; set; }
    }
}
