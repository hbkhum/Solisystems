using Solisystems.Data;
using Solisystems.Domain.Core;
using Solisystems.Domain.Entities;
using Solisystems.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace Solisystems.Repositories
{
    public class ProductEntityRepository : GenericRepositoryEntities<ProductEntity>, IProductEntityRepository
    {
        private readonly DbContextClass _context;

        public ProductEntityRepository(DbContextClass entities)
            : base(entities)
        {
            _context = entities;
        }

        public async Task<ProductEntity> GetById(string id)
        {
            var task = Task.Run(() => dbset.FirstOrDefault(c => c.ProductCode == id));
            return await task;
        }
        public virtual async Task<IReadOnlyList<ProductEntity>> GetAllAsync(string filter, string orderBy, bool lazy = false)
        {
            if (lazy)
            {
                if (filter == "") filter = "true";
                if (orderBy == "") orderBy = "true";
                return await dbset
                    .Include(c => c.Category).AsNoTracking()
                    .Where(filter)
                    .OrderBy(orderBy).ToListAsync();
            }
            return await GetAllAsync(filter, orderBy);
        }
    }
}
