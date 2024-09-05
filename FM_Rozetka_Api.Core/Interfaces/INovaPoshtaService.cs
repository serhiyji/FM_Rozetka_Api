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
    }
}
