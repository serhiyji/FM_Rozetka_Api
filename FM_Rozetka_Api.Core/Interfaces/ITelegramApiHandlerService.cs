
namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface ITelegramApiHandlerService
    {
        Task<bool> SendConfirmationCodeForPhone(string phoneNumber, string code);
    }
}
