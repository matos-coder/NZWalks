﻿using test.api.models.domain;
using test.api.models.DTOs;

namespace test.api.Repositories
{
    public interface IRegionRepository
    {
        Task<List<region>> GetAllAsync(string? sortBy = null, bool isAsending = true,int pageNumber = 1,int pageSize= 1000);

        Task<region?> GetByIdAsync(Guid id);

        Task<region> CreateAsync(region region);
        Task<region?> DeleteAsync(Guid id);
        Task<region> UpdateAsync(Guid id, region region);
    }
}
