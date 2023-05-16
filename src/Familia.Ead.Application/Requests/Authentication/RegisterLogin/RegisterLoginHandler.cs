using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;

namespace Familia.Ead.Application.Requests.Authentication.RegisterLogin
{
    public class RegisterLoginHandler : Handler<RegisterLoginRequest>
    {
        private readonly AppDbContext _context;

        public RegisterLoginHandler(AppDbContext context)
        {
            _context = context;
        }

        public override async Task<Result> Handle(RegisterLoginRequest request, CancellationToken cancellationToken)
        {
            var userLogin = new UserLogins
            {
                Id = Guid.NewGuid(),
                AccessedOn = DateTime.Now,
                UserId = request.UserId
            };

            await _context.UserLogins.AddAsync(userLogin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
