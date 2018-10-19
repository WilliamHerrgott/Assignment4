using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment4
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
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
            builder.HasKey(o => new { o.OrderId, o.ProductId });
        }

    }
}
