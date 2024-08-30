using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Orders.Shipment;
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
    internal class ShipmentService : IShipmentService
    {
        private readonly IRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IRepository<Shipment> shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Shipment, object>> AddAsync(ShipmentCreateDTO model)
        {
            var newShipment = _mapper.Map<Shipment>(model);
            try
            {
                await _shipmentRepository.Insert(newShipment);
                await _shipmentRepository.Save();
                return new ServiceResponse<Shipment, object>(true, "Success", payload: newShipment);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Shipment, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Shipment, object>> UpdateAsync(ShipmentUpdateDTO model)
        {
            var shipment = await _shipmentRepository.GetByID(model.Id);
            if (shipment == null)
            {
                return new ServiceResponse<Shipment, object>(false, "Shipment not found");
            }

            try
            {
                _mapper.Map(model, shipment);
                await _shipmentRepository.Update(shipment);
                await _shipmentRepository.Save();
                return new ServiceResponse<Shipment, object>(true, "Success", payload: shipment);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Shipment, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByID(id);
            if (shipment == null)
            {
                return new ServiceResponse<object, object>(false, "Shipment not found");
            }

            try
            {
                await _shipmentRepository.Delete(shipment.Id);
                await _shipmentRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ShipmentDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var shipment = await _shipmentRepository.GetByID(id);
                if (shipment == null)
                {
                    return new ServiceResponse<ShipmentDTO, object>(false, "Shipment not found");
                }

                return new ServiceResponse<ShipmentDTO, object>(true, "Success", payload: _mapper.Map<ShipmentDTO>(shipment));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ShipmentDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ShipmentDTO>, object>> GetAllAsync()
        {
            try
            {
                var shipments = await _shipmentRepository.GetAll();
                return new ServiceResponse<IEnumerable<ShipmentDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ShipmentDTO>>(shipments));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ShipmentDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
