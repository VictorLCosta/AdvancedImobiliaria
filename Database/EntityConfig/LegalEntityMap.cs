using AdvancedImobiliaria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedImobiliaria.Database.EntityConfig
{
    public class LegalEntityMap : IEntityTypeConfiguration<LegalEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.CompanyName)
                .IsUnique();

            builder.Property(m => m.Status)
                .HasConversion<string>();

            builder.HasMany(m => m.Imoveis)
                .WithOne(m => m.legalEntity)
                .HasForeignKey(m => m.legalEntityId);
        }
    }
}