using Microsoft.AspNetCore.Http;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IFilesService
    {
        Task<string> SaveImage(IFormFile file);

        Task DeleteImage(string name);
    }
}
