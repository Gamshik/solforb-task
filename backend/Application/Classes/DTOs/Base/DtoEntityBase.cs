using Application.Interfaces.Entities.Base;

namespace Application.Classes.DTOs.Base
{
    public class DtoEntityBase : IDtoEntityBase
    {
        public Guid Id { get; set; }
    }
}
