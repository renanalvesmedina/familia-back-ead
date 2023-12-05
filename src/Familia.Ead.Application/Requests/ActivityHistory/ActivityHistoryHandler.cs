using Familia.Ead.Infrastructure.DbContexts;
using MediatR;

namespace Familia.Ead.Application.Requests.ActivityHistory
{
    public class ActivityHistoryHandler : INotificationHandler<ActivityHistoryRequest>
    {
        private readonly AppDbContext _context;

        public ActivityHistoryHandler(AppDbContext context)
        {
            _context = context;
        }

        async Task INotificationHandler<ActivityHistoryRequest>.Handle(ActivityHistoryRequest notification, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ActivityHistory
            {
                UserId = notification.UserId,
                Action = notification.Action,
                ActivityAt = DateTime.Now
            };

            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
