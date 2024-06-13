using DemandForcast.API.Models;

namespace DemandForcast.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();

        Task<ProductModel> CreateAsync(ProductModel product);

        Task<ProductModel> UpdateAsync(Guid Id, ProductModel product);

        Task<ProductModel?> DeleteAsync(Guid Id);

        Task<ProductModel?> GetByIdAsync(Guid Id);
    }
}
