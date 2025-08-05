using Application.Interfaces.Repositories;
using Domain.Entities;
using ORMAdapter.Contexts;
using ORMAdapter.Repositories.Base;

namespace ORMAdapter.Repositories
{
    public class IncomingDocumentRepository(WarehouseDbContext context)
        : BaseRepository<IncomingDocument>(context), IIncomingDocumentRepository
    {
    }
}
