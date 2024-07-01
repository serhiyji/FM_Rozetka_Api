using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Specifications;
using FM_Rozetka_Api.Core.Specifications.Seller;
using Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FM_Rozetka_Api.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository<SellerApplication> _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(IRepository<SellerApplication> sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SellerApplicationDTO>> GetAllApplicationsAsync()
        {
            var applications = await _sellerRepository.GetAll();
            return _mapper.Map<IEnumerable<SellerApplicationDTO>>(applications);
        }

        public async Task<IEnumerable<SellerApplicationDTO>> GetAllActivityApplicationsAsync()
        {
            var applications = await _sellerRepository.GetListBySpec(new SellerTokenSpecification.GetAllActivityApplications());

            if (applications == null)
            {
                return Enumerable.Empty<SellerApplicationDTO>();
            }

            return _mapper.Map<IEnumerable<SellerApplicationDTO>>(applications);
        }


        public async Task<SellerApplicationDTO> GetApplicationByIdAsync(int id)
        {
            var application = await _sellerRepository.GetByID(id);
            return _mapper.Map<SellerApplicationDTO>(application);
        }

        public async Task<SellerApplication> AddApplicationAsync(CreateSellerApplicationDTO application)
        {
            var sellerApplication = _mapper.Map<SellerApplication>(application);
            await _sellerRepository.Insert(sellerApplication);
            await _sellerRepository.Save();
            return sellerApplication;
        }

        public async Task UpdateApplicationStatusAsync(SellerApplicationDTO application)
        {
            UpdateApplicationAsync(_mapper.Map<UpdateSellerApplicationDTO>(application));
        }

        public async Task UpdateApplicationAsync(UpdateSellerApplicationDTO application)
        {
            var sellerApplication = _mapper.Map<SellerApplication>(application);
            await _sellerRepository.Update(sellerApplication);
            await _sellerRepository.Save();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _sellerRepository.Delete(id);
            await _sellerRepository.Save();
        }

       
    }
}
