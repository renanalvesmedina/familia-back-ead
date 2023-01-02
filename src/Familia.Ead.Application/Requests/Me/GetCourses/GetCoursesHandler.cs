using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.GetCourses
{
    public class GetCoursesHandler : Handler<GetCoursesRequest, IEnumerable<GetCoursesResponse>>
    {
        private readonly AppDbContext _context;

        public GetCoursesHandler(AppDbContext context) => _context = context;

        public override async Task<Result<IEnumerable<GetCoursesResponse>>> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
        {
            var result = new List<GetCoursesResponse>();

            var enrolls = await _context.Enrollments.Where(x => x.StudentId == request.UserId).ToListAsync(cancellationToken);

            if (!enrolls.Any())
                return NotFound(ErrorCatalog.Enrollment.NotFound);

            foreach (var enrollment in enrolls)
            {
                var course = await _context.Courses.SingleOrDefaultAsync(x => x.Id == enrollment.CourseId, cancellationToken);

                var lastClassViewed = await _context.StudentHistories.OrderBy(c => c.ViewingDate).LastOrDefaultAsync(
                    x => x.StudentId == request.UserId
                    && x.CourseId == enrollment.Course.Id,
                    cancellationToken);

                var courseResult = new GetCoursesResponse
                {
                    CourseId = course.Id,
                    CourseName = course.CourseName,
                    CourseCardUri = course.CardUri,
                    LastClassAttendedId = lastClassViewed.Id
                };

                result.Add(courseResult);
            }

            return result;
        }
    }
}
