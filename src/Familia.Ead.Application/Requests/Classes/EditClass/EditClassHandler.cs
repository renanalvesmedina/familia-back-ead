using Familia.Ead.Application.Requests.ActivityHistory;
using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Classes.EditClass
{
    public class EditClassHandler : Handler<EditClassRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public EditClassHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public override async Task<Result> Handle(EditClassRequest request, CancellationToken cancellationToken)
        {
            var _class = await _context.Classes.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (request.Name.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Class.InvalidName);

            if (await _context.Classes.AnyAsync(c => c.Name.ToUpper() == request.Name.ToUpper(), cancellationToken))
                return BusinessRuleViolated(ErrorCatalog.Class.Exists);

            _class.Name = request.Name;
            _class.Description = request.Description;
            _class.Video = request.Video;
            _class.Thumb = request.Thumb;
            _class.LaunchDate = request.LaunchDate;

            if(request.OrderId != _class.OrderId)
            {
                var reOrderId = await _context.Classes.Where(c => c.OrderId == request.OrderId).FirstOrDefaultAsync(cancellationToken);
                if(reOrderId != null)
                {
                    reOrderId.OrderId = _class.OrderId;

                    _context.Classes.Update(reOrderId);
                }
            }

            _class.OrderId = request.OrderId;

            _context.Classes.Update(_class);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ActivityHistoryRequest
            {
                UserId = request.UpdatedBy,
                Action = $"Update Class - {request.Id}"
            }, cancellationToken);

            return Success();
        }
    }
}
