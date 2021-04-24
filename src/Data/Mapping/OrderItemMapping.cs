using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);
            builder.Property(orderItem => orderItem.Price)
                .HasColumnType("MONEY")
                .IsRequired();
            builder.Property(orderItem => orderItem.Quantity)
                .IsRequired();
            builder.HasOne(orderItem => orderItem.Book);                                 
        }
    }
}