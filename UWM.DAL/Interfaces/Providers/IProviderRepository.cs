using UWM.DAL.Interfaces.Base;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.Providers
{
    public interface IProviderRepository : IRepositoryGetAll<Provider>, IRepositoryCreate<Provider>, 
        IRepositoryUpdate<Provider>, IRepositoryDelete<Provider>, IRepositoryGet<Provider>
    {
    }
}
