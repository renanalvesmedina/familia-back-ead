using Familia.Ead.Application.Requests.Student.Models;
using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Student.SearchStudentHistory
{
    public class SearchStudentHistoryHandler : Handler<SearchStudentHistoryRequest, IEnumerable<SearchStudentHistoryResponse>>
    {
        private readonly AppDbContext _appDbcontext;
        private readonly UserManager<User> _userManager;

        public SearchStudentHistoryHandler(AppDbContext appDbcontext, UserManager<User> userManager)
        {
            _appDbcontext = appDbcontext;
            _userManager = userManager;
        }

        public override async Task<Result<IEnumerable<SearchStudentHistoryResponse>>> Handle(SearchStudentHistoryRequest request, CancellationToken cancellationToken)
        {
            var result = new List<SearchStudentHistoryResponse>();

            if (!request.StudentId.Equals(Guid.Empty))
            {
                var user = await _userManager.FindByIdAsync(request.StudentId.ToString());

                if(user == null)
                    return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundUser);

                var studentHistories = await _appDbcontext.StudentHistories.Where(a => a.StudentId.Equals(user.Id)).ToListAsync(cancellationToken);

                var histories = new List<StudentHistoryModel>();

                foreach (var history in studentHistories)
                {
                    histories.Add(new StudentHistoryModel
                    {
                        Course = await _appDbcontext.Courses.Where(a => a.Id.Equals(history.CourseId)).Select(c => c.CourseName).SingleOrDefaultAsync(cancellationToken),
                        Class = await _appDbcontext.Classes.Where(c => c.Id.Equals(history.ClassId)).Select(c => c.Name).SingleOrDefaultAsync(cancellationToken),
                        ViewDate = history.ViewingDate.AddHours(-3)
                    });
                }

                result.Add(new SearchStudentHistoryResponse
                {
                    UserId = user.Id,
                    Name = user.FullName,
                    History = histories
                });

                return Success(result);
            }


            var users = await _userManager.GetUsersInRoleAsync(RoleConstants.ROLE_STUDENT);

            foreach (var user in users)
            {
                var studentHistories = await _appDbcontext.StudentHistories.Where(a => a.StudentId.Equals(user.Id)).ToListAsync(cancellationToken);

                var histories = new List<StudentHistoryModel>();

                foreach (var history in studentHistories)
                {
                    histories.Add(new StudentHistoryModel
                    {
                        Course = await _appDbcontext.Courses.Where(a => a.Id.Equals(history.CourseId)).Select(c => c.CourseName).SingleOrDefaultAsync(cancellationToken),
                        Class = await _appDbcontext.Classes.Where(c => c.Id.Equals(history.ClassId)).Select(c => c.Name).SingleOrDefaultAsync(cancellationToken),
                        ViewDate = history.ViewingDate.AddHours(-3)
                    });
                }

                result.Add(new SearchStudentHistoryResponse
                {
                    UserId = user.Id,
                    Name = user.FullName,
                    History = histories
                });
            }

            return Success(result);
        }
    }
}
