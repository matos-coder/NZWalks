using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using test.api.data;
using test.api.models.domain;
using test.api.models.DTOs;

namespace test.api.Repositories
{
    public class SQLregionRepository : IRegionRepository
    {
        private readonly walksDbContext dbContext;

        public SQLregionRepository(walksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<region> CreateAsync(region region)
        {
            await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;

        }

        public async Task<region> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.regions.FirstOrDefaultAsync(y => y.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

           dbContext.regions.Remove(existingRegion);
           await dbContext.SaveChangesAsync();
           return existingRegion;

        }

        public async Task<List<region>> GetAllAsync(string? sortBy = null, bool isAsending = true, int pageNumber = 1, int pageSize = 1000)
        {
            //return await dbContext.regions.ToListAsync();
            //sorting
            var regions = dbContext.regions.AsQueryable();
            if(string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if(sortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    regions = isAsending ? regions.OrderBy(x => x.Name): regions.OrderByDescending(x => x.Name);
                }
            }
            //pagination
            var skipResult = (pageNumber - 1) * pageSize;

            return await regions.Skip(skipResult).Take(pageSize).ToListAsync();
        }


        public async Task<region?> GetByIdAsync(Guid id)
        {
            return await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);   
        }

        public async Task<region> UpdateAsync(Guid id , region region)
        {
            var existingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) 
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImgUrl = region.RegionImgUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }


    }
}
