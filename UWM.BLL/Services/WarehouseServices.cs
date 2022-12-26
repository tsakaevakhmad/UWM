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

        public async Task<int> Create(WarehouseDto warehouse)
        {          
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            return await _repository.Create(_mapper.Map<Warehouse>(warehouse));
        }

        public async Task Delete(int Id)
        {
            await _repository.Delete(Id);
        }

        public async Task<IEnumerable<WarehouseDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<WarehouseDto>>(await _repository.GetAll());
        }

        public async Task Update(WarehouseDto warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            await _repository.Update(_mapper.Map<Warehouse>(warehouse));
        }
    }
}
