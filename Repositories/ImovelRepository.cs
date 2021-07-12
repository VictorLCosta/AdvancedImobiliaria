using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Models.Entities;
using AdvancedImobiliaria.Repositories.Contracts;

namespace AdvancedImobiliaria.Repositories
{
    public class ImovelRepository : Repository<Imovel>, IImovelRepository
    {
        public ImovelRepository(ImobiliariaContext context)
            : base(context)
        {
            
        }
    }
}