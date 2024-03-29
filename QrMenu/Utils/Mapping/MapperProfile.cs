﻿using AutoMapper;
using QrMenu.Models.Restaurant;
using QrMenu.Models.User;
using QrMenu.ViewModels.Restaurant;
using QrMenu.ViewModels.User;

namespace QrMenu.Utils.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User

            CreateMap<UserDatabaseModel, UserView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.IsAdmin ? "Admin" : "User")) // TODO FIX
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));

            CreateMap<UserInsert, UserDatabaseModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserInsert, UserView>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserDatabaseModel, UserLoginResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.IsAdmin ? "Admin" : "User")) // TODO FIX
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));

            CreateMap<UserRegisterRequest, UserDatabaseModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserDatabaseModel, UserRegisterResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Restaurant

            CreateMap<RestaurantInsert, RestaurantDatabaseModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MenuLink, opt => opt.MapFrom(src => src.MenuLink))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website));

            CreateMap<RestaurantDatabaseModel, RestaurantView>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MenuLink, opt => opt.MapFrom(src => src.MenuLink))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime));
        }
    }
}

