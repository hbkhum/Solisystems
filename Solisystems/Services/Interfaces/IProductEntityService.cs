using Solisystems.Domain.Entities;
using System.Linq.Expressions;

namespace Solisystems.Services.Interfaces
{
    public interface IProductEntityService
    {
        Task<bool> CreateProductEntity(ProductEntity productEntity);
        Task<bool> DeleteProductEntity(string id);
        Task<IEnumerable<ProductEntity>> GetAllProductEntities(string filter, string orderBy);
        Task<bool> UpdateProductEntity(ProductEntity productEntity);
        Task<ProductEntity> GetProductEntityById(string id);
    }
}
