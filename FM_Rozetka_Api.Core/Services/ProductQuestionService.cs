using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications.ProductQuestionSpecification;

namespace FM_Rozetka_Api.Core.Services
{
    public class ProductQuestionService : IProductQuestionService
    {
        private readonly IRepository<ProductQuestion> _productQuestionRepository;
        private readonly IMapper _mapper;

        public ProductQuestionService(IMapper mapper, IRepository<ProductQuestion> productQuestionRepository)
        {
            _mapper = mapper;
            _productQuestionRepository = productQuestionRepository;
        }

        public async Task<ServiceResponse<ProductQuestion, object>> AddAsync(ProductQuestionCreateDTO model)
        {
            var newQuestion = _mapper.Map<ProductQuestion>(model);
            try
            {
                await _productQuestionRepository.Insert(newQuestion);
                await _productQuestionRepository.Save();
                return new ServiceResponse<ProductQuestion, object>(true, "Success", payload: newQuestion);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductQuestion, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductQuestion, object>> UpdateAsync(ProductQuestionUpdateDTO model)
        {
            var question = await _productQuestionRepository.GetByID(model.Id);
            if (question == null)
            {
                return new ServiceResponse<ProductQuestion, object>(false, "Question not found");
            }

            try
            {
                _mapper.Map(model, question);
                await _productQuestionRepository.Update(question);
                await _productQuestionRepository.Save();
                return new ServiceResponse<ProductQuestion, object>(true, "Success", payload: question);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductQuestion, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var question = await _productQuestionRepository.GetByID(id);
            if (question == null)
            {
                return new ServiceResponse<object, object>(false, "Question not found");
            }

            try
            {
                await _productQuestionRepository.Delete(question.Id);
                await _productQuestionRepository.Save();
                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductQuestionDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var question = await _productQuestionRepository.GetByID(id);
                if (question == null)
                {
                    return new ServiceResponse<ProductQuestionDTO, object>(false, "Question not found");
                }

                return new ServiceResponse<ProductQuestionDTO, object>(true, "Success", payload: _mapper.Map<ProductQuestionDTO>(question));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductQuestionDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductQuestionDTO>, object>> GetAllAsync()
        {
            try
            {
                var questions = await _productQuestionRepository.GetAll();
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<ProductQuestionDTO>>(questions));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductQuestionDTO>, object>> GetAllByProductIdAsync(int productId)
        {
            if (productId <= 0)
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(false, "Failed productid not found ");
            try
            {
                var questions = (await _productQuestionRepository.GetListBySpec(new ProductQuestionSpecification.GetByProductId(productId))).ToList();

                var map = _mapper.Map<List<ProductQuestionDTO>>(questions);

                for (int i = 0; i < map.Count(); i++)
                {
                    map[i].NameUser = questions[i].AppUser.FirstName + " " + questions[i].AppUser.LastName;
                }
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(true, "Success", payload: map);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductQuestionDTO>, object>> GetActiveQuestions()
        {
            try
            {
                var questions = (await _productQuestionRepository.GetListBySpec(new ProductQuestionSpecification.OpenQuestions())).ToList();

                var map = _mapper.Map<List<ProductQuestionDTO>>(questions);

                for (int i = 0; i < map.Count(); i++)
                {
                    map[i].NameUser = questions[i].AppUser.FirstName + " " + questions[i].AppUser.LastName;
                }
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(true, "Success", payload: map);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<ProductQuestionDTO>, object>(false, "Failed: " + ex.Message);
            }
        }
    }

}
