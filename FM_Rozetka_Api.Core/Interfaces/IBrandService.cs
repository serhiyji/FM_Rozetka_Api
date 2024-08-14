using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IBrandService
    {
        Task<PaginationResponse<List<BrandDTO>, object>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<ServiceResponse<BrandDTO, object>> GetAsync(int id);
        Task<ServiceResponse> AddAsync(BrandCreateDTO brandCreateDTO);
        Task<ServiceResponse> UpdateAsync(BrandUpdateDTO brandUpdateDTO);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
