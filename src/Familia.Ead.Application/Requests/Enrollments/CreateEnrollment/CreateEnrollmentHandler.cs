using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Enrollments.CreateEnrollment
{
    public class CreateEnrollmentHandler : Handler<CreateEnrollmentRequest>
    {
        private readonly AppDbContext _context;

        public CreateEnrollmentHandler(AppDbContext context) => _context = context;

        public override async Task<Result> Handle(CreateEnrollmentRequest request, CancellationToken cancellationToken)
        {
            if (!await _context.Courses.AnyAsync(c => c.Id == request.CourseId, cancellationToken))
                return BusinessRuleViolated(ErrorCatalog.Course.NotFound);

            var enrollment = new Enrollment()
            {
                Id = Guid.NewGuid(),
                StudentId = request.StudentId,
                Status = true,
                CourseId = request.CourseId,
                CreatedOn = DateTime.Now
            };

            await _context.AddAsync(enrollment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
