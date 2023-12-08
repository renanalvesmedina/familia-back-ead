namespace Familia.Ead.Application.Requests.Users.GetUser
{
    public class GetUserResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string PhotoUri { get; set; }
        public IList<string> Profiles { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<CourseEnrollmentsModel> courseEnrollments { get; set; }
    }
}
