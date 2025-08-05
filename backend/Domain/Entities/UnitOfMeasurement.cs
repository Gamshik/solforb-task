using Domain.Entities.Base;

namespace Domain.Entities
{
    public class UnitOfMeasurement : BaseEntity
    {
        public string Title { get; set; }
        public string Status { get; set; }

        public IEnumerable<Balance> Balances { get; set; }
        public IEnumerable<IncomingResource> IncomingResources { get; set; }
        public IEnumerable<OutgoingResource> OutgoingResources { get; set; }
    }
}
