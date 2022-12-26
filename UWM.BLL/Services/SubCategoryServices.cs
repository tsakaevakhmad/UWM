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

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<SubCategoryDto>>(await _repository.GetAll());
        }

        public void Update(SubCategoryDto subCategory)
        {
            if (subCategory == null)
                throw new ArgumentNullException(nameof(subCategory));

            _repository.Update(_mapper.Map<SubCategory>(subCategory));
        }
    }
}
