using Domain.Entities.Base;

namespace Domain.Entities
{
    public class IncomingDocument : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<IncomingResource> IncomingResources { get; set; }
    }
}
