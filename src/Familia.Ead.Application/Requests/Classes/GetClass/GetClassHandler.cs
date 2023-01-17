using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Classes.GetClass
{
    public class GetClassHandler : Handler<GetClassRequest, GetClassResponse>
    {
        private readonly AppDbContext _context;

        public GetClassHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<Result<GetClassResponse>> Handle(GetClassRequest request, CancellationToken cancellationToken)
        {
            var _class = await _context.Classes.SingleOrDefaultAsync(c => c.Id == request.ClassId, cancellationToken);

            if (_class == null)
                return NotFound(ErrorCatalog.Class.NotFound);

            var result = new GetClassResponse
            {
                ClassName = _class.Name,
                OrderId = _class.OrderId,
                Description = _class.Description,
                Video = _class.Video
            };

            return Success(result);
        }
    }
}
