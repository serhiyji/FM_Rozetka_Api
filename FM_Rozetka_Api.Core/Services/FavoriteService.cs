using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    internal class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> _favoriteRepo;
        private readonly IMapper _mapper;
        public FavoriteService(IRepository<Favorite> favoriteRepo, IMapper mapper)
        {
            this._favoriteRepo = favoriteRepo;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<Favorite, object>> AddAsync(FavoriteCreateDTO favoriteCreateDTO)
        {
            var newfavorite = _mapper.Map<Favorite>(favoriteCreateDTO);

            try
            {
                await _favoriteRepo.Insert(newfavorite);
                await _favoriteRepo.Save();
                return new ServiceResponse<Favorite, object>(true, "Favorite created successfully", payload: newfavorite);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Favorite, object>(false, "Failed to create review: " + ex.Message);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            await _favoriteRepo.Delete(id);
            await _favoriteRepo.Save();
            return new ServiceResponse(true, "");
        }

        public async Task<ServiceResponse<List<FavoriteDTO>, object>> GetAllAsync(string appUserId)
        {
            List<Favorite> favorites = (List<Favorite>)await _favoriteRepo.GetListBySpec(new FavoriteSpecification.GetByAppUserId(appUserId));
            return new ServiceResponse<List<FavoriteDTO>, object>(true, "", payload: _mapper.Map<List<Favorite>, List<FavoriteDTO>>(favorites));
        }
    }
}
