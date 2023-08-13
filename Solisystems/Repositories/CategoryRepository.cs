using Solisystems.Data;
using Solisystems.Domain.Core;
using Solisystems.Domain.Entities;
using Solisystems.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Solisystems.Repositories
{
    public class CategoryRepository : GenericRepositoryEntities<Category>, ICategoryRepository
    {


        public CategoryRepository(DbContextClass entities)
            : base(entities)
        { }

        public async Task<Category> GetById(string id)
        {
            var task = Task.Run(() => dbset.FirstOrDefault(c => c.CategoryCode == id));
            return await task;
        }

        public virtual async Task<IReadOnlyList<Category>> GetAllAsync(string filter, string orderBy, bool lazy = false)
        {
            if (lazy)
            {
                if (filter == "") filter = "true";
                if (orderBy == "") orderBy = "true";
                return await dbset
                    .Include(c => c.Products)
                    .Where(filter)
                    .OrderBy(orderBy).ToListAsync();
            }
            return await GetAllAsync(filter, orderBy);
        }
    }
}
