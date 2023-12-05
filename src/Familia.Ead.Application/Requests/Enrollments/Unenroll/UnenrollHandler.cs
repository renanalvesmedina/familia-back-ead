using Familia.Ead.Application.Requests.ActivityHistory;
using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Enrollments.Unenroll
{
    public class UnenrollHandler : Handler<UnenrollRequest>
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public UnenrollHandler(AppDbContext context, UserManager<User> userManager, IMediator mediator)
        {
            _context = context;
            _userManager = userManager;
            _mediator = mediator;
        }

        public override async Task<Result> Handle(UnenrollRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.StudentId.ToString());

            if (user == null)
                return BusinessRuleViolated(ErrorCatalog.User.NotFound);

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId && e.Status, cancellationToken);

            if (enrollment == null)
                return BusinessRuleViolated(ErrorCatalog.Enrollment.NotFound);

            enrollment.Status = false;
            enrollment.UpdatedOn = DateTime.Now;

            _context.Update(enrollment);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ActivityHistoryRequest
            {
                UserId = request.UnenrollBy,
                Action = $"Unenroll - {request.StudentId}"
            }, cancellationToken);

            return Success();
        }
    }
}
