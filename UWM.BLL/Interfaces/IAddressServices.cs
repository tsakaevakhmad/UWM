using UWM.Domain.DTO.Watehouses;

namespace UWM.BLL.Interfaces
{
    public interface IAddressServices
    {
        Task Update(AddressDto address);
    }
}
