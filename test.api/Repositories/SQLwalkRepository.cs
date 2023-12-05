using Microsoft.EntityFrameworkCore;
using test.api.data;
using test.api.models.domain;

namespace test.api.Repositories
{
    public class SQLwalkRepository : IWalkRepository
    {
        private readonly walksDbContext dbContext;

        public SQLwalkRepository(walksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<walk> CreateAsync(walk walk)
        {
            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;  
        }
        public async Task<List<walk>> GetAllAsync()
        {
            return await dbContext.walks.ToListAsync();
        }
    }
}
