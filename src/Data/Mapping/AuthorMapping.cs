using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.OwnsOne(author => author.Name, name =>
            {
                name.Property(e => e.Value)                                                        
                    .IsRequired()
                    .HasColumnName("Name");
            });
            builder.OwnsOne(author => author.Description, description =>
            {
                description.Property(e => e.Value)                                    
                    .IsRequired()
                    .HasColumnName("Description");
            });
            builder.OwnsOne(author => author.Email, email =>
            {
                email.Property(e => e.Address)                                                        
                    .IsRequired()
                    .HasColumnName("Email");
            });
            builder.HasMany(author => author.Books)
                .WithOne(book => book.Author)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}