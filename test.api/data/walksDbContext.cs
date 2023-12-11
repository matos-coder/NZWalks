using Microsoft.EntityFrameworkCore;
using test.api.models.domain;

namespace test.api.data
{
    public class walksDbContext: DbContext
    {
        public walksDbContext(DbContextOptions<walksDbContext> dbConOpt):base(dbConOpt)
        {
            
        }
        public DbSet<difficulty> difficulties { get; set; }
        public DbSet<region> regions { get; set; }
        public DbSet<walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data to difficulties

            var difficulties = new List<difficulty>()
            {
                new difficulty ()
                {
                    Id= Guid.Parse("7fc7a14d-7f58-4d2c-b8a8-d6a32ab24b20"),
                    Name = "Easy"
                },
                new difficulty ()
                {
                    Id= Guid.Parse("0dad2a68-a6a4-4fa3-b8e8-c569574755d4"),
                    Name = "Medium"
                },new difficulty ()
                {
                    Id= Guid.Parse("a70bad79-5326-4f14-ad02-6e557855281f"),
                    Name = "Hard"
                }
                
            };
            modelBuilder.Entity<difficulty>().HasData(difficulties);
        }
    }
}
