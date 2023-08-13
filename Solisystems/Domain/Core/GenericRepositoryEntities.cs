using Microsoft.EntityFrameworkCore;
using Solisystems.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solisystems.Domain.Core
{
    public abstract class GenericRepositoryEntities<T> : IGenericRepositoryEntities<T> where T : class
    {
        private readonly DbContextClass _context;
        protected DbSet<T> dbset;

        protected GenericRepositoryEntities(DbContextClass entities)
        {
            _context = entities;
            dbset = entities.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await dbset.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(string filter, string orderBy)
        {
            if (filter == "") filter = "true";
            if (orderBy == "") orderBy = "true";
            return await dbset.Where(filter).OrderBy(orderBy).ToListAsync();
        }
    }

}
