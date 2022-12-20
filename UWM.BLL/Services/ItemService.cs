using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Items;
using UWM.Domain.DTO.Items;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class ItemService : IItemServices
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository repositoy, IMapper mapper) 
        {
            _repository = repositoy;
            _mapper = mapper;
        }
        public async Task<int> Create(ItemDto item)
        {
            var newItem = _mapper.Map<Item>(item); 
            return await _repository.Create(newItem);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ItemDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return _mapper.Map<ItemDto>(result);
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var resul = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ItemDto>>(resul);
        }

        public async Task<IEnumerable<ItemDto>> GetBySubCategory(int subCategoryid)
        {
            var result = await _repository.GetBySubCategory(subCategoryid);
            return _mapper.Map<IEnumerable<ItemDto>>(result);
        }

        public async Task Update(ItemDto item)
        {
            var update = _mapper.Map<Item>(item);
            await _repository.Update(update);
        }
    }
}
