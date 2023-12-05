using test.api.models.domain;

namespace test.api.Repositories
{
    public interface IWalkRepository
    {
        Task<walk> CreateAsync(walk walk);
        Task<List<walk>> GetAllAsync();
        Task<walk?> GetByIdAsync(Guid id);
        Task<walk> UpdateAsync(Guid id, walk walk);
        Task<walk?> DeleteAsync(Guid id);
    }
}
