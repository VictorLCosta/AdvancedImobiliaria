using AdvancedImobiliaria.Database.EntityConfig;
using AdvancedImobiliaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvancedImobiliaria.Database.Common
{
    public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext(DbContextOptions<ImobiliariaContext> options)
            : base(options)
        {
            
        }

        public DbSet<PhysicalPerson> PhysicalPeople { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<ImovelType> ImovelTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }
        public DbSet<Sale> Sale { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.ApplyConfiguration(new PhysicalPersonMap());
            mb.ApplyConfiguration(new LegalEntityMap());
            mb.ApplyConfiguration(new ImovelEntityMap());
            mb.ApplyConfiguration(new SaleEntityMap());
            mb.ApplyConfiguration(new CityEntityMap());
        }
    }
}