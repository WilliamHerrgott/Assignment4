using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Assignment4
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
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
}
