using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ASPNet_Core.Models
{
    public class AppDBContext:IdentityDbContext<IdentityUser> //DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Product>Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<OrderForm>Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Category 1", Description = "Category 1" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Category 2", Description = "Category 2" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Category 3", Description = "Category 3" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Category 4", Description = "Category 4" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Category 5", Description = "Category 5" });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Pizza 1",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 1,
                ImageUrl = "~/../../Images/11.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Pizza 2",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 2,
                ImageUrl = "~/../../Images/12.jpg"
            });
            modelBuilder.Entity<Product>().HasData( new Product
            {
                ProductId = 3,
                Name = "Pizza 3",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 3,
                ImageUrl = "~/../../Images/13.jpg"
            });
            modelBuilder.Entity<Product>().HasData( new Product
            {
                ProductId = 4,
                Name = "Pizza 4",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 4,
                ImageUrl = "~/../../Images/14.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Pizza 5",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 5,
                ImageUrl = "~/../../Images/15.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Pizza 6",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 1,
                ImageUrl = "~/../../Images/16.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Pizza 7",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = false,
                InStock = true,
                CategoryId = 2,
                ImageUrl = "~/../../Images/17.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Pizza 8",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 3,
                ImageUrl = "~/../../Images/18.jpg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Pizza 9",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 4,
                ImageUrl = "~/../../Images/19.jpg"
            });

        }

    }
}
