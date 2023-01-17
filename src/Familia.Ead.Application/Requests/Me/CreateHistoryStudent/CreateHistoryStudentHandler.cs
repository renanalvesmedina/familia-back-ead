using Familia.Ead.Domain.Entities;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;

namespace Familia.Ead.Application.Requests.Me.CreateHistoryStudent
{
    public class CreateHistoryStudentHandler : Handler<CreateHistoryStudentRequest>
    {
        private readonly AppDbContext _context;

        public CreateHistoryStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<Result> Handle(CreateHistoryStudentRequest request, CancellationToken cancellationToken)
        {
            var studentHistory = new StudentHistory
            {
                Id = Guid.NewGuid(),
                CourseId = request.CourseId,
                ClassId = request.ClassId,
                StudentId = request.StudentId,
                ViewingDate = DateTime.Now
            };

            await _context.StudentHistories.AddAsync(studentHistory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
