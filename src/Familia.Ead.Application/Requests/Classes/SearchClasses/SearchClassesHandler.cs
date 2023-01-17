using AutoMapper;
using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Classes.SearchClasses
{
    public class SearchClassesHandler : Handler<SearchClassesRequest, IEnumerable<SearchClassesResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SearchClassesHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Result<IEnumerable<SearchClassesResponse>>> Handle(SearchClassesRequest request, CancellationToken cancellationToken)
        {
            if (request.CourseId == Guid.Empty)
                return BusinessRuleViolated(ErrorCatalog.Course.NotFound);

            var classes = await _context.Classes.Where(c => c.CourseId == request.CourseId).ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<SearchClassesResponse>>(classes);

            return Success(result);
        }
    }
}
