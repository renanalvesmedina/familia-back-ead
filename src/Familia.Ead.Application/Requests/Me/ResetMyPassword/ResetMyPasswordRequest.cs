using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Me.ResetMyPassword
{
    public class ResetMyPasswordRequest : Request
    {
        public string UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
