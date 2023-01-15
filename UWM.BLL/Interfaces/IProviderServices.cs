using UWM.Domain.DTO.Providers;

namespace UWM.BLL.Interfaces
{
    public interface IProviderServices
    {
        Task<int> Create(ProviderDto provider);
        Task Delete(int id);
        Task<IEnumerable<ProviderDto>> GetAll();
        Task<ProviderDto> Get(int id);
        Task Update(ProviderDto provider);
    }
}
