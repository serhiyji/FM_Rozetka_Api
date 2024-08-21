using FM_Rozetka_Api.Core.DTOs.Brand;
using FM_Rozetka_Api.Core.Responses;
using Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IBrandService
    {
        Task<PaginationResponse<List<BrandDTO>, object>> GetAllPagedAsync(int page = 1, int pageSize = 10);
        Task<ServiceResponse<Brand, object>> AddAsync(BrandCreateDTO model);
        Task<ServiceResponse<Brand, object>> UpdateAsync(BrandUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<ServiceResponse<BrandDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<BrandDTO>, object>> GetAllAsync();
    }
}
