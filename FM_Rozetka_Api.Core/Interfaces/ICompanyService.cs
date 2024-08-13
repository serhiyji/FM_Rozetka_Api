using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllApplicationsAsync();
        Task<CompanyDTO> GetApplicationByIdAsync(int id);
        Task<Company> AddApplicationAsync(CreateCompanyDTO application);
        Task UpdateApplicationAsync(UpdateCompanyDTO application);
        Task DeleteApplicationAsync(int id);
    }
}
