using Lumini.Common.Mediator;

namespace Familia.Ead.Application.Requests.Classes.GetClass
{
    public class GetClassRequest : Request<GetClassResponse>
    {
        public Guid ClassId { get; set; }
    }
}
