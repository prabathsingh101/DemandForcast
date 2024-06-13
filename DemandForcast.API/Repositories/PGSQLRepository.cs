using DemandForcast.API.Data;
using DemandForcast.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Repositories
{
    public class PGSQLRepository: IEmployeeRepository
    {
        private readonly PgApplicationDbContext dbContext;

        public PGSQLRepository(PgApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EmployeeModel> CreateAsync(EmployeeModel employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeModel?> DeleteAsync(Guid Id)
        {
            //check domain model to database
            var existingEmployeeDomainModel = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            //check
            if (existingEmployeeDomainModel == null)
            {
                return null;
            }
            dbContext.Employees.Remove(existingEmployeeDomainModel);
            await dbContext.SaveChangesAsync();
            return existingEmployeeDomainModel;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeModel?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<EmployeeModel> UpdateAsync(Guid Id, EmployeeModel employee)
        {
            //check domain model data from database
            var isExistingEmployeeDomainModel = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            if (isExistingEmployeeDomainModel == null)
            {
                return null;
            }

            isExistingEmployeeDomainModel.Name = employee.Name;

            await dbContext.SaveChangesAsync();

            return isExistingEmployeeDomainModel;
        }
    }
   
}
