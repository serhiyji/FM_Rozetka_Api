using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Interfaces
{
    public interface IShipmentService
    {
        Task<ServiceResponse<IEnumerable<ShipmentDTO>, object>> GetAllAsync();
        Task<ServiceResponse<ShipmentDTO, object>> GetByIdAsync(int id);
        Task<ServiceResponse<Shipment, object>> AddAsync(ShipmentCreateDTO model);
        Task<ServiceResponse<Shipment, object>> UpdateAsync(ShipmentUpdateDTO model);
        Task<ServiceResponse<object, object>> DeleteAsync(int id);
    }
}
