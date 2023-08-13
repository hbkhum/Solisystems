using System.Linq.Expressions;

namespace Solisystems.Domain.Core
{
    public interface IGenericRepositoryEntities<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(string filter, string orderBy);
        Task<IReadOnlyList<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
