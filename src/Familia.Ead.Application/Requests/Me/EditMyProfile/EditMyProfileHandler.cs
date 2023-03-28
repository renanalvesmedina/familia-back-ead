using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.EditMyProfile
{
    public class EditMyProfileHandler : Handler<EditMyProfileRequest>
    {
        private readonly AuthenticationContext _context;

        public EditMyProfileHandler(AuthenticationContext context)
        {
            _context = context;
        }

        public override async Task<Result> Handle(EditMyProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            user.Sexo = request.Sexo;

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
