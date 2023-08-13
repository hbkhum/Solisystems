using Microsoft.EntityFrameworkCore;
using Solisystems.Data;
using Solisystems.Domain.Entities;
using Solisystems.Repositories;
using Solisystems.Repositories.Interfaces;
using Solisystems.Services.Interfaces;
using System.Linq.Expressions;

namespace Solisystems.Services
{
    public class ProductEntityService : IProductEntityService
    {
        private readonly IProductEntityRepository _productEntityRepository;

        public ProductEntityService(IProductEntityRepository productEntityRepository)
        {
            _productEntityRepository = productEntityRepository;
        }

        public async Task<bool> CreateProductEntity(ProductEntity entity)
        {
            var initialId = entity.ProductCode;
            try
            {
                await _productEntityRepository.AddAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteProductEntity(string id)
        {
            var entity = await _productEntityRepository.GetById(id);
            if (entity == null) return false;

            try
            {
                await _productEntityRepository.DeleteAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductEntities(string filter, string orderBy)
        {
            var query = await _productEntityRepository.GetAllAsync(filter, orderBy,true);
            return query;
        }

        public async Task<ProductEntity> GetProductEntityById(string id)
        {
            return await _productEntityRepository.GetById(id);
        }

        public async Task<bool> UpdateProductEntity(ProductEntity entity)
        {
            try
            {
                await _productEntityRepository.EditAsync(entity);
                return true;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
