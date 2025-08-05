using Application.Interfaces.Repositories;
using Domain.Entities;
using ORMAdapter.Contexts;
using ORMAdapter.Repositories.Base;

namespace ORMAdapter.Repositories
{
    public class OutgoingResourceRepository(WarehouseDbContext context)
        : BaseRepository<OutgoingResource>(context), IOutgoingResourceRepository
    {
    }
}
