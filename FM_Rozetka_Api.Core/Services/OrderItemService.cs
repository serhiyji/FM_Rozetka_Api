using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    internal class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IRepository<OrderItem> orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<OrderItem, object>> AddAsync(OrderItemCreateDTO model)
        {
            var newOrderItem = _mapper.Map<OrderItem>(model);
            try
            {
                await _orderItemRepository.Insert(newOrderItem);
                await _orderItemRepository.Save();
                return new ServiceResponse<OrderItem, object>(true, "Success", payload: newOrderItem);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderItem, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderItem, object>> UpdateAsync(OrderItemUpdateDTO model)
        {
            var orderItem = await _orderItemRepository.GetByID(model.Id);
            if (orderItem == null)
            {
                return new ServiceResponse<OrderItem, object>(false, "OrderItem not found");
            }

            try
            {
                _mapper.Map(model, orderItem);
                await _orderItemRepository.Update(orderItem);
                await _orderItemRepository.Save();
                return new ServiceResponse<OrderItem, object>(true, "Success", payload: orderItem);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderItem, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByID(id);
            if (orderItem == null)
            {
                return new ServiceResponse<object, object>(false, "OrderItem not found");
            }

            try
            {
                await _orderItemRepository.Delete(orderItem.Id);
                await _orderItemRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<OrderItemDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetByID(id);
                if (orderItem == null)
                {
                    return new ServiceResponse<OrderItemDTO, object>(false, "OrderItem not found");
                }

                return new ServiceResponse<OrderItemDTO, object>(true, "Success", payload: _mapper.Map<OrderItemDTO>(orderItem));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<OrderItemDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<OrderItemDTO>, object>> GetAllAsync()
        {
            try
            {
                var orderItems = await _orderItemRepository.GetAll();
                return new ServiceResponse<IEnumerable<OrderItemDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<OrderItemDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }

}
