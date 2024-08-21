using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Services
{
    public class CountryProductionService : ICountryProductionService
    {
        private readonly IRepository<CountryProduction> _countryProductionRepository;
        private readonly IMapper _mapper;

        public CountryProductionService(IRepository<CountryProduction> countryProductionRepository, IMapper mapper)
        {
            _countryProductionRepository = countryProductionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CountryProduction, object>> AddAsync(CountryProductionCreateDTO model)
        {
            var country = _mapper.Map<CountryProduction>(model);
            await _countryProductionRepository.Insert(country);
            await _countryProductionRepository.Save();
            return new ServiceResponse<CountryProduction, object>(true, "Succes", payload: country);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryProductionRepository.Delete(id);
            await _countryProductionRepository.Save();
        }

        public async Task<IEnumerable<CountryProductionDTO>> GetAllAsync()
        {
            var country = await _countryProductionRepository.GetAll();
            return _mapper.Map<IEnumerable<CountryProductionDTO>>(country);
        }

        public async Task<CountryProductionDTO> GetByIdAsync(int id)
        {
            var country = await _countryProductionRepository.GetByID(id);
            return _mapper.Map<CountryProductionDTO>(country);
        }

        public async Task<ServiceResponse<CountryProduction, object>> UpdateAsync(CountryProductionUpdateDTO model)
        {
            var country = await _countryProductionRepository.GetByID(model.Id);
            if (country == null)
            {
                return new ServiceResponse<CountryProduction, object>(false, "CountryProduction not found");
            }

            _mapper.Map(model, country);
            await _countryProductionRepository.Update(country);
            await _countryProductionRepository.Save();

            return new ServiceResponse<CountryProduction, object>(true, "Success", payload: country);
        }
    }
}
