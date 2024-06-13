using DemandForcast.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }  
    }
}
