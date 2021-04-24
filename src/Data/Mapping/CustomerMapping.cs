using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{

    namespace CasaCodigo.Data.Mapping
    {
        public class CustomerMapping : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(customer => customer.Id);
                builder.OwnsOne(customer => customer.Email);
                builder.OwnsOne(customer => customer.Document, d =>
                {
                    d.Property(document => document.Number).HasColumnName("Document");
                });
                builder.OwnsOne(customer => customer.Phone, p =>
                {
                    p.Property(phone => phone.Number).HasColumnName("Phone");
                });
                builder.OwnsOne(customer => customer.Address, a =>
                {
                    a.Property(address => address.Street)
                        .HasColumnName("Customer_Street");
                    a.Property(address => address.Complement)
                                    .HasColumnName("Customer_Complement");
                    a.Property(address => address.City)
                                    .HasColumnName("Customer_City");
                    a.Property(address => address.Country)
                                    .HasColumnName("Customer_Country");
                    a.Property(address => address.State)
                                    .HasColumnName("Customer_State");
                    a.Property(address => address.CEP)
                                    .HasColumnName("Customer_CEP");
                });

            }
        }

    }
}
