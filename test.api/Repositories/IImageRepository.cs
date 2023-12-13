using Microsoft.EntityFrameworkCore.Metadata;
using test.api.Migrations;
using test.api.models.domain;

namespace test.api.Repositories
{
    public interface IImageRepository
    {
        Task<image> Upload(image image);
    }
}
