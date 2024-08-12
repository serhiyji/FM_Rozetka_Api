using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Services
{
    public class CompanyService : ICompanyService
    {
        
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(
                IRepository<Company> companyRepository, 
                IMapper mapper
            )
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
           
        }

        public async Task<Company> AddApplicationAsync(CreateCompanyDTO modal)
        {
            var company = _mapper.Map<Company>(modal);
            await _companyRepository.Insert(company);
            await _companyRepository.Save();
            return company;
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _companyRepository.Delete(id);
            await _companyRepository.Save();
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllApplicationsAsync()
        {
            var company = await _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyDTO>>(company);
        }

        public async Task<CompanyDTO> GetApplicationByIdAsync(int id)
        {
            var company = await _companyRepository.GetByID(id);
            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task UpdateApplicationAsync(UpdateCompanyDTO model)
        {
            var company = _mapper.Map<Company>(model);
            await _companyRepository.Update(company);
            await _companyRepository.Save();
        }
    }
}
