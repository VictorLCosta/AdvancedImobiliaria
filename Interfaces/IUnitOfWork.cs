using System;
using System.Threading.Tasks;
using AdvancedImobiliaria.Repositories.Contracts;

namespace AdvancedImobiliaria.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPhysicalPersonRepository PhysicalPerson { get; }
        IImovelRepository ImovelRepository { get ;}
        Task<int> Complete();
    }
}