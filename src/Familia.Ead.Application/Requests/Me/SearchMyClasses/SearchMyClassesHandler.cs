using AutoMapper;
using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.SearchMyClasses
{
    public class SearchMyClassesHandler : Handler<SearchMyClassesRequest, IEnumerable<SearchMyClassesResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SearchMyClassesHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Result<IEnumerable<SearchMyClassesResponse>>> Handle(SearchMyClassesRequest request, CancellationToken cancellationToken)
        {
            var classList = new List<SearchMyClassesResponse>();

            if (request.CourseId == Guid.Empty)
                return BusinessRuleViolated(ErrorCatalog.Course.NotFound);

            var classes = await _context.Classes.Where(c => c.CourseId == request.CourseId).ToListAsync(cancellationToken);

            foreach (var _class in classes)
            {
                // Set if class is pending
                var studentHistory = await _context.StudentHistories.Where(x => x.ClassId == _class.Id && x.StudentId == request.UserId).FirstOrDefaultAsync(cancellationToken);

                if (studentHistory == null)
                {
                    var classResult = new SearchMyClassesResponse
                    {
                        ClassId = _class.Id,
                        ClassName = _class.Name,
                        OrderId = _class.OrderId,
                        IsPending = true,
                        Thumb = _class.Thumb,
                    };
                    
                    classList.Add(classResult);
                }
                else
                {
                    var classResult = new SearchMyClassesResponse
                    {
                        ClassId = _class.Id,
                        ClassName = _class.Name,
                        OrderId = _class.OrderId,
                        IsPending = false,
                        Thumb = _class.Thumb,
                    };

                    classList.Add(classResult);
                }
            }

            var result = _mapper.Map<IEnumerable<SearchMyClassesResponse>>(classList);

            return Success(result);
        }
    }
}
