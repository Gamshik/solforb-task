using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Balance : BaseEntity
    {
        public decimal Quantity { get; set; }

        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public Guid UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
