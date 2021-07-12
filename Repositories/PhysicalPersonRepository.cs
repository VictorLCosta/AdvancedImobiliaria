using System.Threading.Tasks;
using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Models.Entities;
using AdvancedImobiliaria.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AdvancedImobiliaria.Repositories
{
    public class PhysicalPersonRepository : Repository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(ImobiliariaContext context)
            : base(context)
        {
            
        }

		public async Task<PhysicalPerson> GetByEmail(string email)
		{
			return await _context.Set<PhysicalPerson>().SingleOrDefaultAsync(u => u.Email == email);
		}
	}
}