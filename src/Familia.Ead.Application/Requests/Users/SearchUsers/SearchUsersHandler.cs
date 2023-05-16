using Familia.Ead.Domain.Entities.Authentication;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Users.SearchUsers
{
    public class SearchUsersHandler : Handler<SearchUsersRequest, IEnumerable<SearchUsersResponse>>
    {
        private readonly UserManager<User> _userManager;

        public SearchUsersHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public override async Task<Result<IEnumerable<SearchUsersResponse>>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);

            var userListResponse = new List<SearchUsersResponse>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var userResponse = new SearchUsersResponse
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhotoUri = user.ProfilePictureUri,
                    Profile = userRoles
                };

                userListResponse.Add(userResponse);
            }

            return Success(userListResponse);
        }
    }
}
