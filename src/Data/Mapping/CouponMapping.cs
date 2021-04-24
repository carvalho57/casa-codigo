using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{
    public class CouponMapping : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(coupon => coupon.Id);
            builder.Property(coupon => coupon.Code)
                .HasColumnType("VARCHAR(30)");
            builder.Property(coupon => coupon.Percentage);
            builder.Property(coupon => coupon.ExpiryDate)
                .HasColumnType("DATE");            
        }
    }
}