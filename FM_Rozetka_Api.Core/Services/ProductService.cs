using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IFilesService _filesService;

        public ProductService(IMapper mapper, IRepository<Product> productRepository, IFilesService filesService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _filesService = filesService;
        }


        public async Task<ServiceResponse<Product, object>> AddAsync(ProductCreateDTO model)
        { 
            var newProduct = _mapper.Map<Product>(model);
            try
            {
                if (model.ImageFile != null)
                {
                    newProduct.ImageURL = await _filesService.SaveImage(model.ImageFile);
                }
                await _productRepository.Insert(newProduct);
                await _productRepository.Save();
                return new ServiceResponse<Product, object>(true, "Succes", payload: newProduct);
            }
            catch (Exception)
            {
                await _filesService.DeleteImage(newProduct.ImageURL);
                return new ServiceResponse<Product, object>(false, "Failed");
            }
        }
    }
}
