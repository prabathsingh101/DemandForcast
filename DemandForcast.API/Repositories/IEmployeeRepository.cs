using DemandForcast.API.Models;

namespace DemandForcast.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllAsync();

        Task<EmployeeModel> CreateAsync(EmployeeModel employee);

        Task<EmployeeModel> UpdateAsync(Guid Id, EmployeeModel employee);

        Task<EmployeeModel?> DeleteAsync(Guid Id);

        Task<EmployeeModel?> GetByIdAsync(Guid Id);
    }
}
