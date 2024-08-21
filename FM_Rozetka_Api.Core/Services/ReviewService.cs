using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepo;

        public ReviewService(
                IMapper mapper, 
                IRepository<Review> reviewRepository,
                IRepository<Product> productRepo
            )
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _productRepo = productRepo;
        }

        public async Task<ServiceResponse<Review, object>> CreateReview(ReviewCreateDTO reviewDTO)
        {
            var newReview = _mapper.Map<Review>(reviewDTO);
            newReview.CreatedAt = DateTime.UtcNow;

            try
            {
                await _reviewRepository.Insert(newReview);
                await _reviewRepository.Save();
                await UpdateProductRatingAsync(reviewDTO.ProductId);
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
                await UpdateProductRatingAsync(review.ProductId);
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
                await UpdateProductRatingAsync(review.ProductId);
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

        public async Task<ServiceResponse<IEnumerable<ReviewDTO>, object>> GetAllReviewsByProductId(int productId)
        {
            if (productId <= 0)
                return new ServiceResponse<IEnumerable<ReviewDTO>, object>(false, "Failed productid not found ");
            try
            {
                var questions = (await _reviewRepository.GetListBySpec(new ReviewSpecification.GetByProductId(productId))).ToList();

                var map = _mapper.Map<List<ReviewDTO>>(questions);

                for (int i = 0; i < map.Count(); i++)
                {
                    map[i].NameUser = questions[i].AppUser.FirstName + " " + questions[i].AppUser.LastName;
                }
                return new ServiceResponse<IEnumerable<ReviewDTO>, object>(true, "Success", payload: map);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ReviewDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        private async Task<ServiceResponse> UpdateProductRatingAsync(int productId)
        {
            Product product = await _productRepo.GetByID(productId);
            List<Review> reviews = (List<Review>)await _reviewRepository.GetListBySpec(new ReviewSpecification.GetByProductId(productId));
            int count = reviews.Count();
            int summa = reviews.Select(x => x.Rating).ToList().Sum();
            product.Stars = (decimal)summa / (decimal)count;
            await _productRepo.Update(product);
            await _productRepo.Save();
            return new ServiceResponse(true, "");
        }
    }
}