using AutoMapper;
using UWM.BLL.Interfaces;
using UWM.DAL.Interfaces.Providers;
using UWM.Domain.DTO.Providers;
using UWM.Domain.Entity;

namespace UWM.BLL.Services
{
    public class ProviderServices : IProviderServices
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;

        public ProviderServices(IProviderRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(ProviderDto provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            return await _repository.Create(_mapper.Map<Provider>(provider));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ProviderDto> Get(int id)
        {
            return _mapper.Map<ProviderDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<ProviderDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProviderDto>>(await _repository.GetAll());
        }

        public async Task Update(ProviderDto provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            await _repository.Update(_mapper.Map<Provider>(provider));
        }
    }
}
