using AutoMapper;
using System.Net;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Items;
using UWM.Domain.DTO.Items;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemServices(IItemRepository repositoy, IMapper mapper) 
        {
            _repository = repositoy;
            _mapper = mapper;
        }
        public async Task<int> Create(ItemDto item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(item.Title))
                throw new ArgumentNullException(nameof(item.Title));

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

        public async Task<IEnumerable<ItemListDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ItemListDto>>(await _repository.GetAll());
        }

        public async Task<IEnumerable<ItemListDto>> GetBySubCategory(int subCategoryid)
        {
            return _mapper.Map<IEnumerable<ItemListDto>>(await _repository.GetBySubCategory(subCategoryid));
        }

        public async Task Update(ItemDto item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(item.Title))
                throw new ArgumentNullException(nameof(item.Title));

            await _repository.Update(_mapper.Map<Item>(item));
        }
    }
}
