using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Categories;
using UWM.Domain.DTO.Category;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            return await _repository.Create(_mapper.Map<Category>(category));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CategoryDto> Get(int id)
        {
           return _mapper.Map<CategoryDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetAll());
        }

        public async Task Update(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            
            await _repository.Update(_mapper.Map<Category>(category));
        }
    }
}
