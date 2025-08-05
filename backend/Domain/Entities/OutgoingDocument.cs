using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class OutgoingDocument : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DocumentStatus Status { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public IEnumerable<OutgoingResource> OutgoingResources { get; set; }
    }
}
