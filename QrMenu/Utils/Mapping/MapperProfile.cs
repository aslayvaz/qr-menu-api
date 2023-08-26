using AutoMapper;
using QrMenu.Models;
using QrMenu.ViewModels.User;

namespace QrMenu.Utils.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserView>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.IsAdmin ? "Admin" : "User")) // TODO FIX
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));

            CreateMap<UserInsert, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserInsert, UserView>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserLoginResponse>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.IsAdmin ? "Admin" : "User")) // TODO FIX
           .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));

        }
    }
}

