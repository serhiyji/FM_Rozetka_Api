using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.AutoMappers
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<CreateUserDTO, AppUser>().ReverseMap();
            CreateMap<DeleteUserDTO, AppUser>().ReverseMap();
            CreateMap<EditUserDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<UserSignUpEmailDTO, AppUser>().ReverseMap();
            CreateMap<RegistrationUserDTO, CreateUserDTO>().ReverseMap();
            //moderator shop
            CreateMap<UserModeratorShopDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, UserModeratorShopDTO>()
           .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id))
           .ReverseMap()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppUserId));
        }
    }
}
