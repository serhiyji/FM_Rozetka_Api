
using FM_Rozetka_Api.Core.DTOs.Favorite;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<ServiceResponse<List<FavoriteDTO>, object>> GetAllAsync(string appUserId);
        Task<ServiceResponse> AddAsync(FavoriteCreateDTO favoriteCreateDTO);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
