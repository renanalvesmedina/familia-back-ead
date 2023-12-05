using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Courses.GetCourse
{
    public class GetCourseHandler : Handler<GetCourseRequest, GetCourseResponse>
    {
        private readonly AppDbContext _context;

        public GetCourseHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<Result<GetCourseResponse>> Handle(GetCourseRequest request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);

            if (course == null)
                return NotFound(ErrorCatalog.Course.NotFound);

            var workload = await _context.Classes.CountAsync(c => c.CourseId == course.Id, cancellationToken);

            var result = new GetCourseResponse
            {
                CourseName = course.CourseName,
                Description = course.Description,
                Workload = workload,
                CourseCardUri = course.CardUri,
                IsEnabled = course.IsEnabled,
                ExamDate = course.ExamDate,
                CreatedOn = course.CreatedOn
            };

            return Success(result);
        }
    }
}
