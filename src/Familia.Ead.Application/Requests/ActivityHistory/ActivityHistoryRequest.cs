using Lumini.Common.Mediator;
using MediatR;

namespace Familia.Ead.Application.Requests.ActivityHistory
{
    public class ActivityHistoryRequest : INotification
    {
        public Guid UserId { get; set; }
        public string Action { get; set; }
    }
}
