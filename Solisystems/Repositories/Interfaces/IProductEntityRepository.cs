using Solisystems.Domain.Core;
using Solisystems.Domain.Entities;

namespace Solisystems.Repositories.Interfaces
{
    public interface IProductEntityRepository : IGenericRepositoryEntities<ProductEntity>
    {
        Task<ProductEntity> GetById(string id);
        Task<IReadOnlyList<ProductEntity>> GetAllAsync(string filter, string orderBy, bool includeRelated);
    }
}
