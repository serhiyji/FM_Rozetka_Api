using FM_Rozetka_Api.Core.DTOs.CountryProduction;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICountryProductionService
    {
        Task<IEnumerable<CountryProductionDTO>> GetAllAsync();
        Task<CountryProductionDTO> GetByIdAsync(int id);
        Task<ServiceResponse<CountryProduction, object>> AddAsync(CountryProductionCreateDTO model);
        Task<ServiceResponse<CountryProduction, object>> UpdateAsync(CountryProductionUpdateDTO model);
        Task DeleteAsync(int id);
    }
}
