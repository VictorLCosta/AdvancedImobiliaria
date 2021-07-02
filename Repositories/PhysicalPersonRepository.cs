using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Models.Entities;
using AdvancedImobiliaria.Repositories.Contracts;

namespace AdvancedImobiliaria.Repositories
{
    public class PhysicalPersonRepository : Repository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(ImobiliariaContext context)
            : base(context)
        {
            
        }
    }
}