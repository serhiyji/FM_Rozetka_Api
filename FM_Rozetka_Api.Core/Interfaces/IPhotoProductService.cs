using FM_Rozetka_Api.Core.DTOs.Products.PhotoProduct;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IPhotoProductService
    {
        Task<IEnumerable<PhotoProductDTO>> GetAllAsync();
        Task<PhotoProductDTO> GetByIdAsync(int id);
        Task<ServiceResponse<PhotoProduct, object>> AddAsync(PhotoProductCreateDTO model);
        Task<ServiceResponse<PhotoProduct, object>> UpdateAsync(PhotoProductUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
        Task<IEnumerable<PhotoProductDTO>> GetByProductIdAsync(int productId);
    }
}
