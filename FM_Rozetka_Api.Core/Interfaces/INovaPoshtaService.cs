using FM_Rozetka_Api.Core.DTOs.CartItem;
using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.DTOs.NovaPost;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface INovaPoshtaService
    {
        Task<ServiceResponse> GetAreas();
        Task<ServiceResponse> GetSettlements();
        Task<ServiceResponse> GetWarehouses();
        Task<ServiceResponse<List<SettlementDTO>, object>> SearchSettlements(string areaRef, string description);
        Task<ServiceResponse<List<WarehouseDTO>, object>> SearchWarehouses(string settlementRef, string description);
        Task<ServiceResponse<IEnumerable<AreaDTO>, object>> GetAllAsync();

        Task<ServiceResponse<AreaDTO, object>> GetByIdArea(int id);
        Task<ServiceResponse<WarehouseDTO, object>> GetByIdWarehouses(int id);
        Task<ServiceResponse<SettlementDTO, object>> GetByIdSettlements(int id);
    }
}
