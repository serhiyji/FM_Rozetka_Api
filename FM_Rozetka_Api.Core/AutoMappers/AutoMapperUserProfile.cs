using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.AutoMappers
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<UserSignUpEmailDTO, AppUser>().ReverseMap();
        }
    }
}
