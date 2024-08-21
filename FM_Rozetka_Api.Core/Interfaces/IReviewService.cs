using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IReviewService
    {
        Task<ServiceResponse<IEnumerable<ReviewDTO>, object>> GetAllReviews();
        Task<ServiceResponse<IEnumerable<ReviewDTO>, object>> GetAllReviewsByProductId(int productId);
        Task<ServiceResponse<ReviewDTO, object>> GetReviewById(int id);
        Task<ServiceResponse<Review, object>> CreateReview(ReviewCreateDTO reviewDTO);
        Task<ServiceResponse<Review, object>> UpdateReview(ReviewUpdateDTO reviewDTO);
        Task<ServiceResponse<object, object>> DeleteReview(int id);
    }
}
