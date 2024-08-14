using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IReviewService
    {
        Task<ServiceResponse>AddAsync(ReviewCreateDTO reviewCreateDTO);
        Task<ServiceResponse>UpdateAsync(ReviewUpdateDTO reviewUpdateDTO);
        Task<ServiceResponse>DeleteAsync(int id);
        Task<ServiceResponse<List<ReviewDTO>, object>> GetAllByProductIdAsync(int productId);
    }
}
