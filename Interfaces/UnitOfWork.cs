using System.Threading.Tasks;
using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Repositories;
using AdvancedImobiliaria.Repositories.Contracts;

namespace AdvancedImobiliaria.Interfaces
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ImobiliariaContext _context;
        public IPhysicalPersonRepository PhysicalPerson { get; private set; }
		public IImovelRepository ImovelRepository { get; private set; }

		public UnitOfWork(ImobiliariaContext context)
        {
            _context = context;
            PhysicalPerson = new PhysicalPersonRepository(_context);
			ImovelRepository = new ImovelRepository(_context);
        }

		public async Task<int> Complete()
		{
			return await _context.SaveChangesAsync();
		}

		public async void Dispose()
		{
			await _context.DisposeAsync();
		}
	}
}