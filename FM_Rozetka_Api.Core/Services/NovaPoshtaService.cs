using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Discount;
using FM_Rozetka_Api.Core.DTOs.NovaPost;
using FM_Rozetka_Api.Core.Entities.NovaPost;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications.NovaPost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FM_Rozetka_Api.Core.Services
{
    internal class NovaPoshtaService : INovaPoshtaService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IAreaRepository _areaRepository;
        private readonly ISettlementRepository _settlementRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public NovaPoshtaService(IConfiguration configuration, IMapper mapper,
            IAreaRepository areaRepository,
            ISettlementRepository settlementRepository,
            IWarehouseRepository warehouseRepository)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _mapper = mapper;
            _areaRepository = areaRepository;
            _settlementRepository = settlementRepository;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ServiceResponse> GetAreas()
        {
            string key = _configuration.GetValue<string>("NovaposhtaKey");
            NPAreaRequestViewModel model = new NPAreaRequestViewModel
            {
                ApiKey = key,
                ModelName = "Address",
                CalledMethod = "getSettlementAreas",
                MethodProperties = new NPAreaProperties
                {
                    Page = 1,
                    Ref = ""
                }
            };

            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("https://api.novaposhta.ua/v2.0/json/", content);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NPAreaResponseViewModel>(responseData);
                if (result.Data.Any())
                {
                    foreach (var item in result.Data)
                    {
                        var spec = new AreaSpecification.AreaSingleOrDefault(item.Ref);
                        var entity = await _areaRepository.GetItemBySpec(spec);
                        if (entity == null)
                        {
                            entity = _mapper.Map<Area>(item);
                            await _areaRepository.Insert(entity);
                            await _areaRepository.Save();
                        }
                    }
                }
                return new ServiceResponse { Success = true };
            }
            else
            {
                return new ServiceResponse { Success = false, Message = $"Error novaposhta: {response.StatusCode}" };
            }
        }

        public async Task<ServiceResponse> GetSettlements()
        {
            string key = _configuration.GetValue<string>("NovaposhtaKey");
            int page = 1;
            try
            {
                var existingAreas = await _areaRepository.GetAll();
                var areaDict = existingAreas.ToDictionary(a => a.Ref, a => a);

                while (true)
                {
                    NPSettlementRequestViewModel model = new NPSettlementRequestViewModel
                    {
                        ApiKey = key,
                        ModelName = "AddressGeneral",
                        CalledMethod = "getSettlements",
                        MethodProperties = new NPSettlementProperties
                        {
                            Page = page
                        }
                    };

                    string json = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync("https://api.novaposhta.ua/v2.0/json/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<NPSettlementResponseViewModel>(responseData);

                        if (result.Data.Any())
                        {
                            var existingSettlements = await _settlementRepository.GetAll();
                            var settlementDict = existingSettlements.ToDictionary(s => s.Ref, s => s);

                            foreach (var item in result.Data)
                            {
                                if (!settlementDict.ContainsKey(item.Ref))
                                {

                                    if (areaDict.TryGetValue(item.Area, out var area))
                                    {
                                        var entity = _mapper.Map<Settlement>(item);
                                        entity.AreaId = area.Id;
                                        await _settlementRepository.Insert(entity);
                                    }
                                }
                            }
                            await _settlementRepository.Save();
                            page++;
                        }
                        else
                        {
                            return new ServiceResponse { Success = true };
                        }
                    }
                    else
                    {
                        return new ServiceResponse { Success = false, Message = $"Error novaposhta: {response.StatusCode}" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse { Success = false, Message = $"Problem: {ex.Message}" };
            }
        }

        public async Task<ServiceResponse> GetWarehouses()
        {
            string key = _configuration.GetValue<string>("NovaposhtaKey");
            int page = 1;
            try
            {

                while (true)
                {
                    NPWarehouseRequestViewModel model = new NPWarehouseRequestViewModel
                    {
                        ApiKey = key,
                        ModelName = "Address",
                        CalledMethod = "getWarehouses",
                        MethodProperties = new NPWarehouseProperties
                        {
                            Page = page
                        }
                    };

                    string json = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync("https://api.novaposhta.ua/v2.0/json/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<NPWarehouseResponseViewModel>(responseData);
                        if (result.Data.Any())
                        {
                            foreach (var item in result.Data)
                            {
                                var spec = new WarehouseSpecification.WarehouseSingleOrDefault(item.Ref);
                                var entity = await _warehouseRepository.GetItemBySpec(spec);
                                if (entity == null)
                                {
                                    var settlement = await _settlementRepository.GetItemBySpec(new SettlementSpecification.SettlementSingleOrDefault(item.SettlementRef));
                                    if (settlement != null)
                                    {
                                        entity = _mapper.Map<Warehouse>(item);
                                        entity.SettlementId = settlement.Id;
                                        await _warehouseRepository.Insert(entity);
                                    }
                                }
                            }
                            await _warehouseRepository.Save();
                            page++;
                        }
                        else
                        {
                            return new ServiceResponse { Success = true };
                        }
                    }
                    else
                    {
                        return new ServiceResponse { Success = false, Message = $"Error novaposhta: {response.StatusCode}" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse { Success = false, Message = $"Problem: {ex.Message}" };
            }
        }

        public async Task<ServiceResponse<List<SettlementDTO>, object>> SearchSettlements(string areaRef, string description)
        {
            try
            {
                var spec = new SettlementSpecification.SettlementByDescriptionAndArea(areaRef, description);
                var settlements = await _settlementRepository.GetListBySpec(spec);

                var filteredSettlements = _mapper.Map<List<SettlementDTO>>(settlements);

                return new ServiceResponse<List<SettlementDTO>, object>(true, "Success", payload: filteredSettlements);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<SettlementDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<List<WarehouseDTO>, object>> SearchWarehouses(string settlementRef, string description)
        {
            try
            {
                try
                {
                    var spec = new WarehouseSpecification.WarehouseBySettlementAndDescription(settlementRef, description);
                    var warehouses = await _warehouseRepository.GetListBySpec(spec);

                    var filteredWarehouses = _mapper.Map<List<WarehouseDTO>>(warehouses);

                    return new ServiceResponse<List<WarehouseDTO>, object>(true, "Success", payload: filteredWarehouses);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse<List<WarehouseDTO>, object>(false, "Failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<WarehouseDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<IEnumerable<AreaDTO>, object>> GetAllAsync()
        {
            try
            {
                var discounts = await _areaRepository.GetAll();
                return new ServiceResponse<IEnumerable<AreaDTO>, object>(true, "Success", payload: _mapper.Map<IEnumerable<AreaDTO>>(discounts));
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<AreaDTO>, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<SettlementDTO, object>> GetByIdSettlements(int id)
        {
            try
            {
                var settlements = await _settlementRepository.GetByID(id);

                var filteredSettlements = _mapper.Map<SettlementDTO>(settlements);

                return new ServiceResponse<SettlementDTO, object>(true, "Success", payload: filteredSettlements);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<SettlementDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<WarehouseDTO, object>> GetByIdWarehouses(int id)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetByID(id);

                var filteredWarehouse = _mapper.Map<WarehouseDTO>(warehouse);

                return new ServiceResponse<WarehouseDTO, object>(true, "Success", payload: filteredWarehouse);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<WarehouseDTO, object>(false, "Failed: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<AreaDTO, object>> GetByIdArea(int id)
        {
            try
            {
                var area = await _areaRepository.GetByID(id);

                var filteredArea = _mapper.Map<AreaDTO>(area);

                return new ServiceResponse<AreaDTO, object>(true, "Success", payload: filteredArea);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AreaDTO, object>(false, "Failed: " + ex.Message);
            }
        }
    }

}
