using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.NovaPost;
using FM_Rozetka_Api.Core.Entities.NovaPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.AutoMappers
{
    public class NovaPostProfile : Profile
    {
        public NovaPostProfile()
        {
            CreateMap<NPAreaItemViewModel, Area>();
            CreateMap<NPSettlementItemViewModel, Settlement>()
                .ForMember(dest => dest.AreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Area, opt => opt.Ignore());
            CreateMap<NPWarehouseItemViewModel, Warehouse>()
                .ForMember(dest => dest.SettlementId, opt => opt.Ignore())
                .ForMember(dest => dest.Settlement, opt => opt.Ignore());

            CreateMap<Area, AreaDTO>().ReverseMap();
            CreateMap<Settlement, SettlementDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();

        }
    }
}
