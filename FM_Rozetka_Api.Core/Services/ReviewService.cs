using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepo;
        private readonly IMapper _mapper;
        public ReviewService(IRepository<Review> reviewRepo, IMapper mapper)
        {
            this._reviewRepo = reviewRepo;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse> AddAsync(ReviewCreateDTO reviewCreateDTO)
        {
            await _reviewRepo.Insert(_mapper.Map<ReviewCreateDTO, Review>(reviewCreateDTO));
            await _reviewRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            await _reviewRepo.Delete(id);
            await _reviewRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse<List<ReviewDTO>, object>> GetAllByProductIdAsync(int productId)
        {
            List<Review> reviews = (List<Review>)await _reviewRepo.GetListBySpec(new ReviewSpecification.GetByProductId(productId));
            return new ServiceResponse<List<ReviewDTO>, object>(true, "", payload: _mapper.Map<List<Review>, List<ReviewDTO>>(reviews));
        }

        public async Task<ServiceResponse> UpdateAsync(ReviewUpdateDTO reviewUpdateDTO)
        {
            await _reviewRepo.Update(_mapper.Map<ReviewUpdateDTO, Review>(reviewUpdateDTO));
            await _reviewRepo.Save();
            return new ServiceResponse(true, "");
        }
    }
}
