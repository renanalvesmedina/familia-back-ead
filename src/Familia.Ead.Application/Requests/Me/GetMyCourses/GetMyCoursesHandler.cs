using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.GetMyCourses
{
    public class GetMyCoursesHandler : Handler<GetMyCoursesRequest, IEnumerable<GetMyCoursesResponse>>
    {
        private readonly AppDbContext _context;

        public GetMyCoursesHandler(AppDbContext context) => _context = context;

        public override async Task<Result<IEnumerable<GetMyCoursesResponse>>> Handle(GetMyCoursesRequest request, CancellationToken cancellationToken)
        {
            var result = new List<GetMyCoursesResponse>();

            var enrolls = await _context.Enrollments.Where(x => x.StudentId == request.UserId && x.Status == true).ToListAsync(cancellationToken);

            if (!enrolls.Any())
                return NotFound(ErrorCatalog.Enrollment.NotFound);

            foreach (var enrollment in enrolls)
            {
                var course = await _context.Courses.SingleOrDefaultAsync(x => x.Id == enrollment.CourseId, cancellationToken);

                var studentClassHistory = await _context.StudentHistories.OrderBy(c => c.ViewingDate).LastOrDefaultAsync(
                    x => x.StudentId == request.UserId
                    && x.CourseId == enrollment.Course.Id,
                    cancellationToken);

                var lastClassViewed = studentClassHistory == null
                    ? await _context.Classes.Where(c => c.Course == course && c.OrderId == 1).Select(c => c.Id).SingleOrDefaultAsync(cancellationToken)
                    : studentClassHistory.ClassId;

                var courseResult = new GetMyCoursesResponse
                {
                    CourseId = course.Id,
                    CourseName = course.CourseName,
                    CourseCardUri = course.CardUri,
                    LastClassAttendedId = lastClassViewed,
                };

                result.Add(courseResult);
            }

            return result;
        }
    }
}
