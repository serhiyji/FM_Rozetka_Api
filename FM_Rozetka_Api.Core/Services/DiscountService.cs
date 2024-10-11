using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Discount;
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
    internal class DiscountService : IDiscountService
    {
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IRepository<Discount> discountRepository, IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<Discount, object>> AddAsync(DiscountCreateDTO model)
        {
            var newDiscount = _mapper.Map<Discount>(model);
            try
            {
                newDiscount.StartDate = newDiscount.StartDate.ToUniversalTime();
                newDiscount.EndDate = newDiscount.EndDate.ToUniversalTime();

                await _discountRepository.Insert(newDiscount);
                await _discountRepository.Save();

                var product = await _productRepository.GetByID(newDiscount.ProductId);
                if (product != null)
                {
                    if (newDiscount.StartDate <= DateTime.UtcNow)
                    {
                        product.Price = CalculateDiscountedPrice(product.Price, newDiscount);
                        product.HasDiscount = true; 
                        await _productRepository.Update(product);
                        await _productRepository.Save();
                    }
                }

                return new ServiceResponse<Discount, object>(true, "Success", payload: newDiscount);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Discount, object>(false, "Failed: " + ex.Message);
            }
        }


        public async Task<ServiceResponse<object, object>> ActivateScheduledDiscountsAsync()
        {
            try
            {
                var upcomingDiscounts = await _discountRepository.GetListBySpec(new DiscountSpecifications.GetUpcomingDiscounts());

                foreach (var discount in upcomingDiscounts)
                {
                    var product = await _productRepository.GetByID(discount.ProductId);
                    if (product != null && !product.HasDiscount)
                    {
                        product.Price = CalculateDiscountedPrice(product.Price, discount);
                        product.HasDiscount = true;
                        await _productRepository.Update(product);
                    }
                }

                await _productRepository.Save();

                return new ServiceResponse<object, object>(true, "Scheduled discounts have been successfully activated.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Error activating scheduled discounts: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<Discount, object>> UpdateAsync(DiscountUpdateDTO model)
        {
            var discount = await _discountRepository.GetByID(model.Id);
            if (discount == null)
            {
                return new ServiceResponse<Discount, object>(false, "Discount not found");
            }

            try
            {
                var product = await _productRepository.GetByID(discount.ProductId);
                if (product != null)
                {
                    product.Price = CalculateOriginalPrice(product.Price, discount);

                    _mapper.Map(model, discount);
                    discount.StartDate = discount.StartDate.ToUniversalTime();
                    discount.EndDate = discount.EndDate.ToUniversalTime();

                    await _discountRepository.Update(discount);
                    await _discountRepository.Save();

                    if (discount.StartDate <= DateTime.UtcNow)
                    {
                        product.Price = CalculateDiscountedPrice(product.Price, discount);
                        product.HasDiscount = true; 
                    }
                    else
                    {
                        product.HasDiscount = false; 
                    }

                    await _productRepository.Update(product);
                    await _productRepository.Save();

                    return new ServiceResponse<Discount, object>(true, "Success", payload: discount);
                }

                return new ServiceResponse<Discount, object>(false, "Failed to update discount");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Discount, object>(false, "Failed: " + ex.Message);
            }
        }


        public async Task<ServiceResponse<object, object>> DeleteAsync(int id)
        {
            var discount = await _discountRepository.GetByID(id);
            if (discount == null)
            {
                return new ServiceResponse<object, object>(false, "Discount not found");
            }

            try
            {
                await _discountRepository.Delete(discount.Id);
                await _discountRepository.Save();

                var product = await _productRepository.GetByID(discount.ProductId);
                if (product != null)
                {
                    product.Price = CalculateOriginalPrice(product.Price, discount);
                    await _productRepository.Update(product);
                    await _productRepository.Save();
                }

                return new ServiceResponse<object, object>(true, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<DiscountDTO, object>> GetByIdAsync(int id)
        {
            try
            {
                var discount = await _discountRepository.GetByID(id);
                if (discount == null)
                {
                    return new ServiceResponse<DiscountDTO, object>(false, "Discount not found");
                }

                return new ServiceResponse<DiscountDTO, object>(true, "Success", payload: _mapper.Map<DiscountDTO>(discount));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DiscountDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<DiscountDTO>, object>> GetByProductIdAsync(int id)
        {
            try
            {
                var discount = await _discountRepository.GetListBySpec(new DiscountSpecification.GetByProductId(id));
                if (discount == null)
                {
                    return new ServiceResponse<IEnumerable<DiscountDTO>, object>(false, "Discount not found");
                }

                return new ServiceResponse<IEnumerable<DiscountDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<DiscountDTO>>(discount));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<DiscountDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<DiscountDTO>, object>> GetAllAsync()
        {
            try
            {
                var discounts = await _discountRepository.GetAll();
                return new ServiceResponse<IEnumerable<DiscountDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<DiscountDTO>>(discounts));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<DiscountDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<object, object>> DeleteExpiredDiscountsAsync()
        {
            try
            {
                var expiredDiscounts = await _discountRepository.GetListBySpec(new DiscountSpecifications.GetExpiredDiscounts());

                foreach (var discount in expiredDiscounts)
                {
                    var product = await _productRepository.GetByID(discount.ProductId);
                    if (product != null)
                    {
                        product.Price = CalculateOriginalPrice(product.Price, discount);
                        await _productRepository.Update(product);
                    }

                    await _discountRepository.Delete(discount.Id);
                }

                await _discountRepository.Save();
                await _productRepository.Save();

                return new ServiceResponse<object, object>(true, "Expired discounts have been successfully removed.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object, object>(false, "Error removing expired discounts:" + ex.Message);
            }
        }

        private decimal CalculateDiscountedPrice(decimal originalPrice, Discount discount)
        {
            return Math.Round(originalPrice - (originalPrice * discount.DiscountPercent / 100), 2);
        }

        private decimal CalculateOriginalPrice(decimal discountedPrice, Discount discount)
        {
            return Math.Round(discountedPrice / (1 - discount.DiscountPercent / 100), 2);
        }

    }

}
