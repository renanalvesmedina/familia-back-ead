using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Courses.CreateCourse
{
    public class CreateCourseHandler : Handler<CreateCourseRequest>
    {
        private readonly AppDbContext _context;

        public CreateCourseHandler(AppDbContext context) => _context = context;

        public override async Task<Result> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            if (request.CourseName.Length < 3)
                return BusinessRuleViolated(ErrorCatalog.Course.InvalidName);

            if(await _context.Courses.AnyAsync(c => c.CourseName.ToUpper() == request.CourseName.ToUpper(), cancellationToken))
                return BusinessRuleViolated(ErrorCatalog.Course.Exists);

            var course = new Course()
            {
                Id = Guid.NewGuid(),
                CourseName = request.CourseName,
                Description = request.Description,
                IsEnabled = true,
                Workload = 0,
                CreatedOn = DateTime.Now
            };

            await _context.AddAsync(course, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
