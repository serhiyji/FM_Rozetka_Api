using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IMapper mapper, IRepository<Review> reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<ServiceResponse<Review, object>> CreateReview(ReviewCreateDTO reviewDTO)
        {
            var newReview = _mapper.Map<Review>(reviewDTO);
            newReview.CreatedAt = DateTime.UtcNow;

            try
            {
                await _reviewRepository.Insert(newReview);
                await _reviewRepository.Save();
                return new ServiceResponse<Review, object>(true, "Review created successfully", payload: newReview);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Review, object>(false, "Failed to create review: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Review, object>> UpdateReview(ReviewUpdateDTO reviewDTO)
        {
            var review = await _reviewRepository.GetByID(reviewDTO.Id);
            if (review == null)
            {
                return new ServiceResponse<Review, object>(false, "Review not found");
            }

            try
            {
                _mapper.Map(reviewDTO, review);
                await _reviewRepository.Update(review);
                await _reviewRepository.Save();
                return new ServiceResponse<Review, object>(true, "Review updated successfully", payload: review);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Review, object>(false, "Failed to update review: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteReview(int id)
        {
            var review = await _reviewRepository.GetByID(id);
            if (review == null)
            {
                return new ServiceResponse<object, object>(false, "Review not found");
            }

            try
            {
                await _reviewRepository.Delete(review.Id);
                await _reviewRepository.Save();
                return new ServiceResponse<object, object>(true, "Review deleted successfully");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed to delete review: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ReviewDTO, object>> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewRepository.GetByID(id);
                if (review == null)
                {
                    return new ServiceResponse<ReviewDTO, object>(false, "Review not found");
                }

                var reviewDTO = _mapper.Map<ReviewDTO>(review);
                return new ServiceResponse<ReviewDTO, object>(true, "Review retrieved successfully", payload: reviewDTO);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ReviewDTO, object>(false, "Failed to retrieve review: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ReviewDTO>, object>> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepository.GetAll();
                var reviewDTOs = _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
                return new ServiceResponse<IEnumerable<ReviewDTO>, object>(true, "Reviews retrieved successfully", payload: reviewDTOs);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ReviewDTO>, object>(false, "Failed to retrieve reviews: " + ex.Message);
            }
        }

      
    }

}
