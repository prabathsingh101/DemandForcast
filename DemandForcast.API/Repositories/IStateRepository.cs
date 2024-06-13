using DemandForcast.API.Models;

namespace DemandForcast.API.Repositories
{
    public interface IStateRepository
    {
        Task<List<StateModel>> GetAllAsync();

        Task<StateModel> CreateAsync(StateModel employee);

        Task<StateModel> UpdateAsync(Guid Id, StateModel employee);

        Task<StateModel?> DeleteAsync(Guid Id);

        Task<StateModel?> GetByIdAsync(Guid Id);
    }
}
