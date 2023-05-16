namespace Familia.Ead.Domain.Entities.Authentication
{
    public class UserLogins
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime AccessedOn { get; set; }
    }
}
