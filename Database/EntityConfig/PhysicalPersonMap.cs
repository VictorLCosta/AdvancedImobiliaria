using AdvancedImobiliaria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvancedImobiliaria.Database.EntityConfig
{
    public class PhysicalPersonMap : IEntityTypeConfiguration<PhysicalPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Status)
                .HasConversion<string>();

            builder.HasOne(m => m.City);

            builder.Property(m => m.Gender)
                .HasMaxLength(1);

            builder.HasMany(m => m.Imoveis)
                .WithOne(m => m.physicalPerson)
                .HasForeignKey(m => m.physicalPersonId);

            builder.HasMany(m => m.Sales)
                .WithOne(m => m.physicalPerson)
                .HasForeignKey(m => m.physicalUserId);
        }
    }
}