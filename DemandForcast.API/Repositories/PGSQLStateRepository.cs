using DemandForcast.API.Data;
using DemandForcast.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Repositories
{
    public class PGSQLStateRepository : IStateRepository
    {
        private readonly PgApplicationDbContext dbContext;

        public PGSQLStateRepository(PgApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<StateModel> CreateAsync(StateModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<StateModel?> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StateModel>> GetAllAsync()
        {
            string sqlQuery = "SELECT * FROM public.\"States\" ORDER BY \"Id\" ASC";
            //return await dbContext.States.ToListAsync();

            return await dbContext.States.FromSqlRaw(sqlQuery).ToListAsync();
        }

        public Task<StateModel?> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StateModel> UpdateAsync(Guid Id, StateModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
