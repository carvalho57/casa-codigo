using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaCodigo.Data.Mapping
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(state => state.Id);
            builder.Property(state => state.Name)   
                .HasColumnType("varchar(70)")
                .IsRequired();
            builder.Property(state => state.Abbreviation)
                .HasColumnType("varchar(5)")
                .IsRequired();                                    
        }
    }
}