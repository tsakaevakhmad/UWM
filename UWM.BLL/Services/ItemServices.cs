using AutoMapper;
using System.Net;
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
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return await _repository.Create(_mapper.Map<Item>(item));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ItemDto> Get(int id)
        {
            return _mapper.Map<ItemDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ItemDto>>(await _repository.GetAll());
        }

        public async Task<IEnumerable<ItemDto>> GetBySubCategory(int subCategoryid)
        {
            return _mapper.Map<IEnumerable<ItemDto>>(await _repository.GetBySubCategory(subCategoryid));
        }

        public async Task Update(ItemDto item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await _repository.Update(_mapper.Map<Item>(item));
        }
    }
}
