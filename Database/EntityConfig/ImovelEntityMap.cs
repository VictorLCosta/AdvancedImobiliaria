using AdvancedImobiliaria.Models.Entities;
using AdvancedImobiliaria.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedImobiliaria.Database.EntityConfig
{
    public class ImovelEntityMap : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Status)
                .HasConversion<string>();

            builder.HasQueryFilter(m => m.Status != ImovelStatus.Sold);

            
        }
    }
}