using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public IEnumerable<OutgoingDocument> OutgoingDocuments { get; set; }
    }
}
