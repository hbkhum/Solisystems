using Microsoft.EntityFrameworkCore;
using Solisystems.Domain.Entities;
using Solisystems.Repositories.Interfaces;
using Solisystems.Services.Interfaces;
using System.Linq.Expressions;

namespace Solisystems.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateCategory(Category entity)
        {
            var initialId = entity.CategoryCode;

            try
            {
                await _categoryRepository.AddAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var entity = await _categoryRepository.GetById(id);
            if (entity == null) return false;

            try
            {
                await _categoryRepository.DeleteAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories(string filter, string orderBy)
        {
            var query = await _categoryRepository.GetAllAsync(filter, orderBy,true);
            return query;
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<bool> UpdateCategory(Category entity)
        {
            try
            {
                await _categoryRepository.EditAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
