using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var CategoriesList = new List<Category>() {
                new Category { Id = 1, Name="Fruits", DisplayOrder = 1},
                new Category { Id = 2, Name="Vegetables", DisplayOrder = 2}
            };


            var ProductList = new List<Product> {
                new Product { Id = 1, Name="Banana", Price = 3, Supplier="Mall city", Weight = 3, ISBN="100",Quantity=1, CategoryId=1, ImageUrl=""},
                new Product { Id = 2, Name="Apples", Price = 4, Supplier="Mall city", Weight = 3, ISBN="100", Quantity=1, CategoryId=2, ImageUrl=""}
            };

            modelBuilder.Entity<Category>().HasData(CategoriesList);
            modelBuilder.Entity<Product>().HasData(ProductList);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }



       
    }
}
