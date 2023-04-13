using Familia.Ead.Application.Utils;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Me.UpdateMyAvatar
{
    public class UpdateMyAvatarHandler : Handler<UpdateMyAvatarRequest>
    {
        private readonly AuthenticationContext _context;
        private readonly IUploadFileFactory _uploadFactory;

        public UpdateMyAvatarHandler(IUploadFileFactory uploadFactory, AuthenticationContext context)
        {
            _uploadFactory = uploadFactory;
            _context = context;
        }

        public override async Task<Result> Handle(UpdateMyAvatarRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
                return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundUser);

            var profileUri = await _uploadFactory.UploadFileAsync(request.Image, "imagesprofile", request.UserId.ToString());

            if (profileUri == null)
                return BusinessRuleViolated(ErrorCatalog.GenericWithMessage("Erro para atualizar sua imagem de perfil!"));

            user.ProfilePictureUri = profileUri;

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
