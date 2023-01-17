namespace Familia.Ead.Application.Requests.Classes.SearchClasses
{
    public class SearchClassesResponse
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public string Thumb { get; set; }
    }
}
