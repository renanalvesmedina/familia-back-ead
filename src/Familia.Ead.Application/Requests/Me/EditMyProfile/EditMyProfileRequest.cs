using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.EditMyProfile
{
    public class EditMyProfileRequest : Request
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Sexo { get; set; }
    }
}
