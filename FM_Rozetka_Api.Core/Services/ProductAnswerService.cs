using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
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
    public class ProductAnswerService : IProductAnswerService
    {
        private readonly IRepository<ProductAnswer> _productAnswerRepository;
        private readonly IMapper _mapper;

        public ProductAnswerService(IMapper mapper, IRepository<ProductAnswer> productAnswerRepository)
        {
            _mapper = mapper;
            _productAnswerRepository = productAnswerRepository;
        }

        public async Task<ServiceResponse<ProductAnswerDTO, object>> CreateAsync(ProductAnswerCreateDTO model)
        {
            var newAnswer = _mapper.Map<ProductAnswer>(model);
            try
            {
                newAnswer.CreatedAt = DateTime.UtcNow;
                await _productAnswerRepository.Insert(newAnswer);
                await _productAnswerRepository.Save();
                return new ServiceResponse<ProductAnswerDTO, object>(true, "Success", payload: _mapper.Map<ProductAnswerDTO>(newAnswer));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductAnswerDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductAnswerDTO, object>> UpdateAsync(ProductAnswerUpdateDTO model)
        {
            var answer = await _productAnswerRepository.GetByID(model.Id);
            if (answer == null)
            {
                return new ServiceResponse<ProductAnswerDTO, object>(false, "Answer not found");
            }

            try
            {
                _mapper.Map(model, answer);
                await _productAnswerRepository.Update(answer);
                await _productAnswerRepository.Save();
                return new ServiceResponse<ProductAnswerDTO, object>(true, "Success", payload: _mapper.Map<ProductAnswerDTO>(answer));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductAnswerDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var answer = await _productAnswerRepository.GetByID(id);
            if (answer == null)
            {
                return new ServiceResponse<object, object>(false, "Answer not found");
            }

            try
            {
                await _productAnswerRepository.Delete(answer.Id);
                await _productAnswerRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductAnswerDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var answer = await _productAnswerRepository.GetByID(id);
                if (answer == null)
                {
                    return new ServiceResponse<ProductAnswerDTO, object>(false, "Answer not found");
                }

                return new ServiceResponse<ProductAnswerDTO, object>(true, "Success", payload: _mapper.Map<ProductAnswerDTO>(answer));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductAnswerDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductAnswerDTO>, object>> GetAllAsync()
        {
            try
            {
                var answers = await _productAnswerRepository.GetAll();
                return new ServiceResponse<IEnumerable<ProductAnswerDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ProductAnswerDTO>>(answers));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductAnswerDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
