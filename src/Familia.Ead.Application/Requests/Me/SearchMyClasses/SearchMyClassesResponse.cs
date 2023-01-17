namespace Familia.Ead.Application.Requests.Me.SearchMyClasses
{
    public class SearchMyClassesResponse
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public int OrderId { get; set; }
        public string Thumb { get; set; }
        public bool IsPending { get; set; }
    }
}
