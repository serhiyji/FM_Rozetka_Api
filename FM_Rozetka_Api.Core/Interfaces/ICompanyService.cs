using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
