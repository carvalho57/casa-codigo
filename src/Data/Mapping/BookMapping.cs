using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.Property(book => book.ISBN)
                .IsRequired();
            builder.Property(book => book.ResumeContent)
                .HasColumnName("Resume")
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(book => book.NumberPages)
                .HasColumnType("SMALLINT")
                .IsRequired();
            builder.Property(book => book.Price)
                .HasColumnType("MONEY")
                .IsRequired();
            builder.Property(book => book.Summary)                
                .IsRequired();
            builder.Property(book => book.Title)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();
            builder.Property(book => book.ReleaseDate)
                .HasColumnType("DATE")
                .IsRequired();
            builder.HasOne(book => book.Author);
            builder.HasOne(book => book.Category);
        }

    }
}