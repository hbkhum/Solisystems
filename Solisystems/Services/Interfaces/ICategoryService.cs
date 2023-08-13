using Solisystems.Domain.Entities;
using System.Linq.Expressions;

namespace Solisystems.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(Category category);
        Task<bool> DeleteCategory(string id);
        Task<IEnumerable<Category>> GetAllCategories(string filter, string orderBy);
        Task<bool> UpdateCategory(Category category);
        Task<Category> GetCategoryById(string id);
    }


}
