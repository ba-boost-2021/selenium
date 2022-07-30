using BilgeAdam.Automation.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.Automation.Context
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,12000;Database=Northwind;User Id=sa;Password=1q2w3e4R!");
        }
    }
}