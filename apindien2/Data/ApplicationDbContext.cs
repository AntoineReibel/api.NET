using apindien2.Models;
using Microsoft.EntityFrameworkCore;

namespace apindien2;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Villa> Villa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Villa>().HasData(
        new Villa
        {
            Id = 1,
            Name = "Villa 1",
            Surface = 100,
            Occupancy = 4,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Villa
        {
            Id = 2,
            Name = "Villa 2",
            Surface = 200,
            Occupancy = 6,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
        );
    }

}