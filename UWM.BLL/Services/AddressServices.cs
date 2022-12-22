using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Addresses;
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _repository;

        public AddressServices(IAddressRepository repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Update(AddressDto address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            await _repository.Update(_mapper.Map<Address>(address));
        }
    }
}
