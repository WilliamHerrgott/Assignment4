using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4
{
    public class Product
    {
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
            builder.Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            builder.Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
        }
    }
}
