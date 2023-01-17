using AutoMapper;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Courses.SearchCourses
{
    public class SearchCoursesHandler : Handler<SearchCoursesRequest, IEnumerable<SearchCoursesResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SearchCoursesHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Result<IEnumerable<SearchCoursesResponse>>> Handle(SearchCoursesRequest request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses.Where(c => c.IsEnabled == request.IsEnabled).ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<SearchCoursesResponse>>(courses);
            
            return Success(result);
        }
    }
}
