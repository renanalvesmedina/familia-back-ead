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
                return result;

            foreach (var enrollment in enrolls)
            {
                var course = await _context.Courses.SingleOrDefaultAsync(x => x.Id == enrollment.CourseId, cancellationToken);

                var studentClassesHistory = await _context.StudentHistories
                    .Where(x => x.StudentId == request.UserId && x.CourseId == enrollment.Course.Id)
                    .OrderBy(c => c.ViewingDate)
                    .ToListAsync(cancellationToken);

                var lastClassViewed = !studentClassesHistory.Any()
                    ? await _context.Classes.Where(c => c.Course == course && c.OrderId == 1).Select(c => c.Id).SingleOrDefaultAsync(cancellationToken)
                    : studentClassesHistory.Select(c => c.ClassId).LastOrDefault();

                var courseResult = new GetMyCoursesResponse
                {
                    CourseId = course.Id,
                    CourseName = course.CourseName,
                    CourseCardUri = course.CardUri,
                    LastClassAttendedId = lastClassViewed,
                    TotalCourseClasses = course.Workload,
                    TotalCompletedClasses = studentClassesHistory.DistinctBy(c => c.ClassId).Count()
                };

                result.Add(courseResult);
            }

            return result;
        }
    }
}
