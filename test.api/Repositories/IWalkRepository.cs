using test.api.models.domain;

namespace test.api.Repositories
{
    public interface IWalkRepository
    {
        Task<walk> CreateAsync(walk walk);
        Task<List<walk>> GetAllAsync();
    }
}
