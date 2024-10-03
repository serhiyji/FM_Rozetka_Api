using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
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
    internal class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<Payment> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Payment, object>> AddAsync(PaymentCreateDTO model)
        {
            var newPayment = _mapper.Map<Payment>(model);
            try
            {
                await _paymentRepository.Insert(newPayment);
                await _paymentRepository.Save();
                return new ServiceResponse<Payment, object>(true, "Success", payload: newPayment);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Payment, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Payment, object>> UpdateAsync(PaymentUpdateDTO model)
        {
            var payment = await _paymentRepository.GetByID(model.Id);
            if (payment == null)
            {
                return new ServiceResponse<Payment, object>(false, "Payment not found");
            }

            try
            {
                _mapper.Map(model, payment);
                await _paymentRepository.Update(payment);
                await _paymentRepository.Save();
                return new ServiceResponse<Payment, object>(true, "Success", payload: payment);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Payment, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var payment = await _paymentRepository.GetByID(id);
            if (payment == null)
            {
                return new ServiceResponse<object, object>(false, "Payment not found");
            }

            try
            {
                await _paymentRepository.Delete(payment.Id);
                await _paymentRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }
        

        public async Task<ServiceResponse<IEnumerable<PaymentDTO>, object>> GetAllByOrderIdAsync(int shopid)
        {
            try
            {
                var payment = await _paymentRepository.GetListBySpec(new PaymentSpecification.GetByOrderId(shopid));
                if (payment == null)
                {
                    return new ServiceResponse<IEnumerable<PaymentDTO>, object>(false, "Payment not found");
                }

                return new ServiceResponse<IEnumerable<PaymentDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<PaymentDTO>>(payment));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<PaymentDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<PaymentDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var payment = await _paymentRepository.GetByID(id);
                if (payment == null)
                {
                    return new ServiceResponse<PaymentDTO, object>(false, "Payment not found");
                }

                return new ServiceResponse<PaymentDTO, object>(true, "Success", payload: _mapper.Map<PaymentDTO>(payment));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<PaymentDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<PaymentDTO>, object>> GetAllAsync()
        {
            try
            {
                var payments = await _paymentRepository.GetAll();
                return new ServiceResponse<IEnumerable<PaymentDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<PaymentDTO>>(payments));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<PaymentDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
