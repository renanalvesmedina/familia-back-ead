using Familia.Ead.Application.Utils;
using Familia.Ead.Domain.Entities.Authentication;
using Familia.Ead.Infrastructure.DbContexts;
using Lumini.Common.Mediator;
using Lumini.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Familia.Ead.Application.Requests.Users.GetUser
{
    public class GetUserHandler : Handler<GetUserRequest, GetUserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;

        public GetUserHandler(UserManager<User> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public override async Task<Result<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return BusinessRuleViolated(ErrorCatalog.Authentication.NotFoundUser);

            var userRoles = await _userManager.GetRolesAsync(user);

            var _courseEnrollments = new List<CourseEnrollmentsModel>();

            var enrollments = await _context.Enrollments.Where(x => x.StudentId == request.UserId).ToListAsync(cancellationToken);

            foreach(var enrollment in enrollments)
            {
                var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == enrollment.CourseId, cancellationToken);
                var studentClassesHistory = await _context.StudentHistories
                    .Where(x => x.StudentId == request.UserId && x.CourseId == enrollment.Course.Id)
                    .OrderBy(c => c.ViewingDate)
                    .ToListAsync(cancellationToken);

                var lastClassViewed = !studentClassesHistory.Any()
                    ? await _context.Classes.Where(c => c.Course == course && c.OrderId == 1).Select(c => c.Id).SingleOrDefaultAsync(cancellationToken)
                    : studentClassesHistory.Select(c => c.ClassId).LastOrDefault();

                var courseEnrollment = new CourseEnrollmentsModel
                {
                    CourseId = course.Id,
                    CourseName = course.CourseName,
                    LastClassAttendeceId = lastClassViewed,
                    TotalCourseClasses = course.Workload,
                    TotalCompletedClasses = studentClassesHistory.DistinctBy(c => c.ClassId).Count(),
                    EnrollmentDate = enrollment.CreatedOn
                };

                _courseEnrollments.Add(courseEnrollment);
            }

            var result = new GetUserResponse
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Gender = user.Sexo,
                PhotoUri = user.ProfilePictureUri,
                Profiles = userRoles,
                CreatedAt = user.CreatedOn,
                courseEnrollments = _courseEnrollments
            };

            return Success(result);
        }
    }
}
