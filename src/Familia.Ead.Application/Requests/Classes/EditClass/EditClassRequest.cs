using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Classes.EditClass
{
    public class EditClassRequest : Request
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public string Thumb { get; set; }
        public DateTime LaunchDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
