using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using test.api.data;
using test.api.Migrations;
using test.api.models.domain;

namespace test.api.Repositories
{
    public class SQLImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly walksDbContext dbContext;
        private readonly walksDbContext walksDbContext;

        public SQLImageRepository(IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor,walksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<image> Upload(image image)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images",$"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await image.File.CopyToAsync(stream);
            // https://localhost:1234/Images/image.png
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            await dbContext.images.AddAsync(image);
            await dbContext.SaveChangesAsync();
            return image;
        }
    }
}
