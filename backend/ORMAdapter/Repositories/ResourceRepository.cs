using Application.Interfaces.Repositories;
using Domain.Entities;
using ORMAdapter.Contexts;
using ORMAdapter.Repositories.Base;

namespace ORMAdapter.Repositories
{
    public class ResourceRepository(WarehouseDbContext context)
        : BaseRepository<Resource>(context), IResourceRepository
    {
    }
}
