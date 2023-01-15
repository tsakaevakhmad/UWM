using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.SubCategories;
using UWM.Domain.DTO.SubCategory;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class SubCategoryServices : ISubCategoryServices
    {
        private readonly ISubCategoryRepository _repository;
        private readonly IMapper _mapper;

        public SubCategoryServices(ISubCategoryRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(SubCategoryDto subCategory)
        {
            if (subCategory == null)
                throw new ArgumentNullException(nameof(subCategory));

            return await _repository.Create(_mapper.Map<SubCategory>(subCategory));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<SubCategoryDto> Get(int id)
        {
            return _mapper.Map<SubCategoryDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<SubCategoryDto>>(await _repository.GetAll());
        }

        public async Task Update(SubCategoryDto subCategory)
        {
            if (subCategory == null)
                throw new ArgumentNullException(nameof(subCategory));

            await _repository.Update(_mapper.Map<SubCategory>(subCategory));
        }
    }
}
