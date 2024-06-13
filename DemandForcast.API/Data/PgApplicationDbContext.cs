using DemandForcast.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Data
{
    public class PgApplicationDbContext: DbContext
    {
        public PgApplicationDbContext(DbContextOptions<PgApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<StateModel> States { get; set; }
    }
}
