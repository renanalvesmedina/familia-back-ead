using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Users.EditUser
{
    public class EditUserRequest : Request
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public IList<string> Profiles { get; set; }
    }
}
