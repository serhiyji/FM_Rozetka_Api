using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.ProductAnswer;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
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
    public class ProductAnswerService : IProductAnswerService
    {
        private readonly IRepository<ProductAnswer> _productAnswerRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<ProductQuestion> _productQuestionRepository;

        public ProductAnswerService(IMapper mapper, IRepository<ProductAnswer> productAnswerRepository, IRepository<ProductQuestion> productQuestionRepository)
        {
            _mapper = mapper;
            _productAnswerRepository = productAnswerRepository;
            _productQuestionRepository = productQuestionRepository;
        }

        public async Task<ServiceResponse<ProductAnswerDTO, object>> CreateAsync(ProductAnswerCreateDTO model)
        {
            var newAnswer = _mapper.Map<ProductAnswer>(model);
            try
            {
                var question = await _productQuestionRepository.GetByID(model.QuestionID);
                if (question == null)
                {
                    return new ServiceResponse<ProductAnswerDTO, object>(false, "Question not found");
                }
                if (question.hasAnswer != true) 
                {
                    question.hasAnswer = true;

                    await _productQuestionRepository.Update(question);
                    await _productQuestionRepository.Save();
                }
                

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
                var countAnswer = await _productAnswerRepository.GetCountBySpec(new ProductAnswerSpecification.GetCountAnswer(answer.QuestionID));
                if (countAnswer == 0)
                {
                    var question = await _productQuestionRepository.GetByID(answer.QuestionID);
                    if (question == null)
                    {
                        return new ServiceResponse<object, object>(false, "Question not found");
                    }
                    question.hasAnswer = false;
                    await _productQuestionRepository.Update(question);
                    await _productQuestionRepository.Save();
                }
              

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

        public async Task<ServiceResponse<IEnumerable<ProductAnswerDTO>, object>> GetAllByQuestionId(int questionId)
        {
            if (questionId <= 0)
                return new ServiceResponse<IEnumerable<ProductAnswerDTO>, object>(false, "Failed productid not found ");
            try
            {
                var questions = (await _productAnswerRepository.GetListBySpec(new ProductAnswerSpecification.GetByQustionId(questionId))).ToList();

                var map = _mapper.Map<List<ProductAnswerDTO>>(questions);

                for (int i = 0; i < map.Count(); i++)
                {
                    map[i].NameUser = questions[i].AppUser.FirstName + " " + questions[i].AppUser.LastName;
                }
                return new ServiceResponse<IEnumerable<ProductAnswerDTO>, object>(true, "Success", payload: map);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductAnswerDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }
}
