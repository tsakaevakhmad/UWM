using Microsoft.EntityFrameworkCore;
using UWM.Domain.DTO.Providers;
using UWM.Domain.Entity;

namespace UWM.BLL.Interfaces
{
    public interface IProviderServices
    {
        Task<int> Create(ProviderDto provider);
        Task Delete(int id);
        Task<IEnumerable<ProviderDto>> GetAll();
        Task Update(ProviderDto provider);
    }
}
