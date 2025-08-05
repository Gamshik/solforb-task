using Domain.Interfaces.Base;

namespace Domain.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
