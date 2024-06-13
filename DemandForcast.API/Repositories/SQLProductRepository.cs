using DemandForcast.API.Data;
using DemandForcast.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductModel> CreateAsync(ProductModel product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel?> DeleteAsync(Guid Id)
        {
            //check domain model to database
            var existingProductDomainModel = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            //check
            if (existingProductDomainModel == null)
            {
                return null;
            }
            dbContext.Products.Remove(existingProductDomainModel);
            await dbContext.SaveChangesAsync();
            return existingProductDomainModel;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync(); 
        }

        public async Task<ProductModel?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task <ProductModel> UpdateAsync(Guid Id, ProductModel product)
        {
            //check domain model data from database
            var isExistingProductDomainModel = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (isExistingProductDomainModel == null)
            {
                return null;
            }

            isExistingProductDomainModel.ProductName = product.ProductName;
            isExistingProductDomainModel.ProductDescription = product.ProductDescription;          
            isExistingProductDomainModel.Rate = product.Rate;
            isExistingProductDomainModel.Quantity = product.Quantity;            
            isExistingProductDomainModel.Total = product.Total;

            await dbContext.SaveChangesAsync();
            return isExistingProductDomainModel;
        }
    }
}
