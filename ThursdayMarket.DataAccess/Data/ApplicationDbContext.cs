using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Data
{
    public class ApplicationDbContext :  IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var CategoriesList = new List<Category>() {
        new Category { Id = 1, Name = "Fruits", DisplayOrder = 1 },
        new Category { Id = 2, Name = "Vegetables", DisplayOrder = 2 }
    };

            var ProductList = new List<Product> {
        new Product { Id = 1, Name = "Banana", Price = 3, Supplier = "Mall city", Weight = 3, ISBN = "100", Quantity = 1, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1587132137056-bfbf0166836e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=880&q=80" },
        new Product { Id = 2, Name = "Apple", Price = 4, Supplier = "Mall city", Weight = 3, ISBN = "100", Quantity = 1, CategoryId = 2, ImageUrl = "https://images.unsplash.com/photo-1603189864361-0cc65b5ecd3a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80" },
        new Product { Id = 3, Name = "Orange", Price = 2.5, Supplier = "Fruit King", Weight = 2, ISBN = "101", Quantity = 1, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1611080626919-7cf5a9dbab5b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80" },
        new Product { Id = 4, Name = "Carrot", Price = 1.5, Supplier = "Veggie Farm", Weight = 1, ISBN = "102", Quantity = 1, CategoryId = 2, ImageUrl = "https://images.unsplash.com/photo-1590868309235-ea34bed7bd7f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=327&q=80" },
        new Product { Id = 5, Name = "Grapes", Price = 5, Supplier = "Vineyard Co.", Weight = 4, ISBN = "103", Quantity = 1, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1625499940894-8796928bf9c4?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=410&q=80" },
        new Product { Id = 6, Name = "Broccoli", Price = 2, Supplier = "Veggie Farm", Weight = 2, ISBN = "104", Quantity = 1, CategoryId = 2, ImageUrl = "https://images.unsplash.com/photo-1583663848850-46af132dc08e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80" },
        new Product { Id = 7, Name = "Watermelon", Price = 6, Supplier = "Fruit King", Weight = 7, ISBN = "105", Quantity = 1, CategoryId = 1, ImageUrl = "https://images.unsplash.com/photo-1587049352846-4a222e784d38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=880&q=80" }
    };

            modelBuilder.Entity<Category>().HasData(CategoriesList);
            modelBuilder.Entity<Product>().HasData(ProductList);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }



    }
}
