using AutoMapper;
using System.Linq;
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

        public async Task<int> Create(WarehouseDto warehouse)
        {          
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            if (string.IsNullOrEmpty(warehouse.Number))
                throw new ArgumentNullException(nameof(warehouse.Number));

            if (warehouse.AddressDto == null)
                throw new ArgumentNullException(nameof(warehouse.AddressDto));

            if (string.IsNullOrEmpty(warehouse.AddressDto.Country))
                throw new ArgumentNullException(nameof(warehouse.AddressDto.Country));

            return await _repository.Create(_mapper.Map<Warehouse>(warehouse));
        }

        public async Task Delete(int Id)
        {
            await _repository.Delete(Id);
        }

        public async Task<WarehouseDto> Get(int id)
        {
            return _mapper.Map<WarehouseDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<WarehouseDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<WarehouseDto>>(await _repository.GetAll());
        }

        public async Task Update(WarehouseDto warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            if (string.IsNullOrEmpty(warehouse.Number))
                throw new ArgumentNullException(nameof(warehouse.Number));
            
            if (warehouse.AddressDto == null)
                throw new ArgumentNullException(nameof(warehouse.AddressDto));

            if (string.IsNullOrEmpty(warehouse.AddressDto.Country))
                throw new ArgumentNullException(nameof(warehouse.AddressDto.Country));

            await _repository.Update(_mapper.Map<Warehouse>(warehouse));
        }
    }
}
