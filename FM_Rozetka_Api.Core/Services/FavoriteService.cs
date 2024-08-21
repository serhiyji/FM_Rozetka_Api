using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Favorite;
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
        public async Task<ServiceResponse> AddAsync(FavoriteCreateDTO favoriteCreateDTO)
        {
            Favorite favorite = _mapper.Map<FavoriteCreateDTO, Favorite>(favoriteCreateDTO);
            await _favoriteRepo.Insert(favorite);
            await _favoriteRepo.Save();
            return new ServiceResponse(true, "");
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
