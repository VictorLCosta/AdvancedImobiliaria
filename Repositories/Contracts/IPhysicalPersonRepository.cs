using System.Threading.Tasks;
using AdvancedImobiliaria.Models.Entities;

namespace AdvancedImobiliaria.Repositories.Contracts
{
    public interface IPhysicalPersonRepository : IRepository<PhysicalPerson>
    {
        Task<PhysicalPerson> GetByEmail(string email);
    }
}