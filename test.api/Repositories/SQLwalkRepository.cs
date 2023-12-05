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
            return await dbContext.walks.Include("difficulty").Include("region").ToListAsync();
        }
        public async Task<walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.walks.Include("difficulty").Include("region").FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<walk> UpdateAsync(Guid id, walk walk)
        {
            var existingRegion = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Name = walk.Name;
            existingRegion.Description = walk.Description;
            existingRegion.LengthInKm = walk.LengthInKm;
            existingRegion.regionId = walk.regionId;
            existingRegion.difficultyId = walk.difficultyId;
            existingRegion.WalkImgUrl = walk.WalkImgUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
        public async Task<walk> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.walks.FirstOrDefaultAsync(y => y.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            dbContext.walks.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
