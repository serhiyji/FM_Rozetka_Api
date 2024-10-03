using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Orders.OrderStatusHistory;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    internal class OrderStatusHistoryService : IOrderStatusHistoryService
    {
        private readonly IRepository<OrderStatusHistory> _orderStatusHistoryRepository;
        private readonly IMapper _mapper;

        public OrderStatusHistoryService(IRepository<OrderStatusHistory> orderStatusHistoryRepository, IMapper mapper)
        {
            _orderStatusHistoryRepository = orderStatusHistoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<OrderStatusHistory, object>> AddAsync(OrderStatusHistoryCreateDTO model)
        {
            var newOrderStatusHistory = _mapper.Map<OrderStatusHistory>(model);
            try
            {
                await _orderStatusHistoryRepository.Insert(newOrderStatusHistory);
                await _orderStatusHistoryRepository.Save();
                return new ServiceResponse<OrderStatusHistory, object>(true, "Success", payload: newOrderStatusHistory);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderStatusHistory, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderStatusHistory, object>> UpdateAsync(OrderStatusHistoryUpdateDTO model)
        {
            var orderStatusHistory = await _orderStatusHistoryRepository.GetByID(model.Id);
            if (orderStatusHistory == null)
            {
                return new ServiceResponse<OrderStatusHistory, object>(false, "OrderStatusHistory not found");
            }

            try
            {
                _mapper.Map(model, orderStatusHistory);
                await _orderStatusHistoryRepository.Update(orderStatusHistory);
                await _orderStatusHistoryRepository.Save();
                return new ServiceResponse<OrderStatusHistory, object>(true, "Success", payload: orderStatusHistory);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderStatusHistory, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var orderStatusHistory = await _orderStatusHistoryRepository.GetByID(id);
            if (orderStatusHistory == null)
            {
                return new ServiceResponse<object, object>(false, "OrderStatusHistory not found");
            }

            try
            {
                await _orderStatusHistoryRepository.Delete(orderStatusHistory.Id);
                await _orderStatusHistoryRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderStatusHistoryDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var orderStatusHistory = await _orderStatusHistoryRepository.GetByID(id);
                if (orderStatusHistory == null)
                {
                    return new ServiceResponse<OrderStatusHistoryDTO, object>(false, "OrderStatusHistory not found");
                }

                return new ServiceResponse<OrderStatusHistoryDTO, object>(true, "Success", payload: _mapper.Map<OrderStatusHistoryDTO>(orderStatusHistory));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderStatusHistoryDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>> GetAllAsync()
        {
            try
            {
                var orderStatusHistories = await _orderStatusHistoryRepository.GetAll();
                return new ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<OrderStatusHistoryDTO>>(orderStatusHistories));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>(false, "Failed: " + ex.Message);
            }
        }


        public async Task<ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>> GetByOrdersIdAsync(int Orderid)
        {
            try
            {
                var orderStatusHistories = await _orderStatusHistoryRepository.GetListBySpec(new OrderStatusHistorySpecification.GetByOidreId(Orderid));
                return new ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<OrderStatusHistoryDTO>>(orderStatusHistories));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<OrderStatusHistoryDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

    }
}
