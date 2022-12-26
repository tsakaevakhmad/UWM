using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Warehouses;
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class WarehouseServices : IWarehouseServices
    {
        private readonly IWarehouseRepository _repository;
        private readonly IMapper _mapper;

        public WarehouseServices(IWarehouseRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<int> Create(AddressDto address, Warehouse warehouse)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            return await _repository.Create(_mapper.Map<Address>(address), _mapper.Map<Warehouse>(warehouse));
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return _mapper.Map<IEnumerable<Warehouse>>(await _repository.GetAll());
        }

        public void Update(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));
            
            _repository.Update(warehouse);
        }
    }
}
