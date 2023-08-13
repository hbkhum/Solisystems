using Solisystems.Domain.Core;
using Solisystems.Domain.Entities;

namespace Solisystems.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepositoryEntities<Category>
    {
        Task<Category> GetById(string id);
        Task<IReadOnlyList<Category>> GetAllAsync(string filter, string orderBy, bool includeRelated);
    }
}
