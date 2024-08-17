using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IReviewService
    {
        Task<ServiceResponse<IEnumerable<ReviewDTO>, object>> GetAllReviews();
        Task<ServiceResponse<ReviewDTO, object>> GetReviewById(int id);
        Task<ServiceResponse<Review, object>> CreateReview(ReviewCreateDTO reviewDTO);
        Task<ServiceResponse<Review, object>> UpdateReview(ReviewUpdateDTO reviewDTO);
        Task<ServiceResponse<object, object>> DeleteReview(int id);
    }

}
