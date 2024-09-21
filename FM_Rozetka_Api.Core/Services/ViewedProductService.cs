using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.AspNetCore.Identity;

namespace FM_Rozetka_Api.Core.Services
{
    internal class ViewedProductService : IViewedProductService
    {
        private readonly IRepository<ViewedProduct> _viewedProductRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly UserManager<AppUser> _userManager;
        public ViewedProductService(
                IRepository<ViewedProduct> viewedProductRepo,
                IRepository<Product> productRepo,
                UserManager<AppUser> userManager
            )
        {
            this._viewedProductRepo = viewedProductRepo;
            this._productRepo = productRepo;
            this._userManager = userManager;
        }
        public async Task<ServiceResponse> AddProduct(int productId, string appUserId)
        {
            ViewedProduct viewedProduct = await _viewedProductRepo.GetItemBySpec(new ViewedProductSpecification.GetByAppUserIdAndProductId(appUserId, productId));
            if (viewedProduct != null)
            {
                viewedProduct.CreatedAt = DateTime.UtcNow;
                viewedProduct.Count++;
                await _viewedProductRepo.Update(viewedProduct);
                await _viewedProductRepo.Save();
                Product product1 = await _productRepo.GetByID(productId);
                product1.Showings++;
                await _productRepo.Update(product1);
                await _productRepo.Save();
                return new ServiceResponse(true);
            }
            
            Product product = await _productRepo.GetByID(productId);
            if (product == null) return new ServiceResponse(false);
            AppUser appUser = await _userManager.FindByIdAsync(appUserId);
            if (appUser == null) return new ServiceResponse(false);

            product.Showings++;
            await _productRepo.Update(product);
            await _productRepo.Save();

            await _viewedProductRepo.Insert(new ViewedProduct()
            {
                ProductId = productId,
                AppUserId = appUserId,
                CreatedAt = DateTime.UtcNow,
                Count = 1
            });
            await _viewedProductRepo.Save();

            return new ServiceResponse(true);
        }

        public async Task<ServiceResponse> GetByAppUserId(string appUserId, int count)
        {
            return new ServiceResponse(true, "", await _viewedProductRepo.GetListBySpec(new ViewedProductSpecification.GetByAppUserIdCount(appUserId, count)));
        }

        public async Task<ServiceResponse> GetRecommendedProducts(string appUserId, int count)
        {
            AppUser appUser = await _userManager.FindByIdAsync(appUserId);
            if (appUser == null) return new ServiceResponse(false);
            return new ServiceResponse(true, "", await _viewedProductRepo.GetListBySpec(new ViewedProductSpecification.GetRecommendedProductsByAppUserIdCount(appUserId, count)));
        }
    }
}
