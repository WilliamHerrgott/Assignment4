using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Assignment4
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.Property(x => x.Id).HasColumnName("categoryid");
            builder.Property(x => x.Name).HasColumnName("categoryname");
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitsInStock { get; set; }
        public Category Category { get; set; }
    }
    
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.Property(x => x.Id).HasColumnName("productid");
            builder.Property(x => x.CategoryId).HasColumnName("categoryid");
            builder.Property(x => x.Name).HasColumnName("productname");
            builder.Property(x => x.UnitPrice).HasColumnName("unitprice");
            builder.Property(x => x.QuantityPerUnit).HasColumnName("quantityperunits");
            builder.Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
        }
    }

    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
    
    class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("orderdetails");
            builder.Property(x => x.OrderId).HasColumnName("orderid");
            builder.Property(x => x.ProductId).HasColumnName("productid");
            builder.Property(x => x.UnitPrice).HasColumnName("unitprice");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.Property(x => x.Discount).HasColumnName("discount");
        }
    }
    
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }
    
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.Property(x => x.Id).HasColumnName("orderid");
            builder.Property(x => x.Date).HasColumnName("orderdate");
            builder.Property(x => x.Required).HasColumnName("requireddate");
            builder.Property(x => x.ShipName).HasColumnName("shipname");
            builder.Property(x => x.ShipCity).HasColumnName("shipcity");
        }
    }
    
    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=localhost;db=library;uid=user;pwd=postgresqlpwd");
            // you only need this if you want to see the SQL statments created
            // by EF
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging();
        }

        private static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());


        }
        
    }
    
    public class DataService
    {
        public ICollection<Category> GetCategories()
        {
//            using (var context = new Context())
//            {
//                var cat = context.Categories.Take(-1);
//                return cat;
//            }
        }
        
        public Category GetCategory(int id)
        {
            using (var context = new Context())
            {
                var cat = context.Categories
                    .Single(b => b.Id == id);
                return cat;
            }
        }

        public Category CreateCategory(string name, string description)
        {
//            var optionsBuilder = new DbContextOptionsBuilder<Context>();
//            optionsBuilder.UseNpgsql("Server=localhost;Database=library");
//            using (var db = new Context(optionsBuilder.Options))
//            {
//                var _cat = new Category {Name = name, Description = description};
//                db.Categories.Add(_cat);
//                db.SaveChanges();
//                return _cat;
//            }
            return null;
        }

        public bool DeleteCategory(int id)
        {
            return false;
        }
        
        public bool UpdateCategory(int id, string newName, string newDescription)
        {
            return false;
        }

        public Product GetProduct(int id)
        {
            return null;
        }
        
        public List<Product> GetProductByName(string name)
        {
            return null;
        }
        
        public List<Product> GetProductByCategory(int categoryId)
        {
            return null;
        }

        public Order GetOrder(int id)
        {
            return null;
        }
        
        public List<Order> GetOrders()
        {
            return null;
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            return null;
        }
        
        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            return null;
        }
    }
}