using AdvancedImobiliaria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedImobiliaria.Database.EntityConfig
{
    public class SaleEntityMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Imovel)
                .WithOne(m => m.Sale);

            builder.HasOne(m => m.physicalPerson)
                .WithMany(m => m.Sales)
                .HasForeignKey(m => m.physicalUserId);

            builder.HasOne(m => m.legalEntity)
                .WithMany(m => m.Sales)
                .HasForeignKey(m => m.legalUserId);
        }
    }
}