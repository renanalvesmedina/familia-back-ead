using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;

namespace Familia.Ead.Application.Requests.Courses.EditCourse
{
    public class EditCourseHandler : Handler<EditCourseRequest>
    {
        private readonly AppDbContext _context;

        public EditCourseHandler(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public override async Task<Result> Handle(EditCourseRequest request, CancellationToken cancellationToken)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == request.CourseId);

            if (request.CourseName.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Course.InvalidName);

            if (request.CourseName.ToUpper().Equals(course.CourseName.ToUpper()))
                return BusinessRuleViolated(ErrorCatalog.Course.Exists);

            course.CourseName = request.CourseName;
            course.Description = request.Description;
            course.Workload = request.Workload;
            course.CardUri = request.CardUri;
            course.ExamDate = request.ExamDate;
            course.IsEnabled = request.IsEnabled;
            course.UpdatedOn = DateTime.Now;

            _context.Update(course);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
