using Application.Interfaces.Repositories;
using Domain.Entities;
using ORMAdapter.Contexts;
using ORMAdapter.Repositories.Base;

namespace ORMAdapter.Repositories
{
    public class IncomingResourceRepository(WarehouseDbContext context)
        : BaseRepository<IncomingResource>(context), IIncomingResourceRepository
    {
    }
}
