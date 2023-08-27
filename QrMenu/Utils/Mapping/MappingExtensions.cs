using AutoMapper;
using QrMenu.Models.Restaurant;
using QrMenu.Models.User;
using QrMenu.ViewModels.Restaurant;
using QrMenu.ViewModels.User;

namespace QrMenu.Utils.Mapping
{
    public static class MappingExtensions
    {
        private static readonly IMapper _mapper;

        static MappingExtensions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //users
                cfg.CreateMap<UserDatabaseModel, UserView>();
                cfg.CreateMap<UserInsert, UserDatabaseModel>();
                cfg.CreateMap<UserDatabaseModel, UserLoginResponse>();
                cfg.CreateMap<UserRegisterRequest, UserDatabaseModel>();
                cfg.CreateMap<UserDatabaseModel, UserRegisterResponse>();

                // restaurants
                cfg.CreateMap<RestaurantInsert, RestaurantDatabaseModel>();
                cfg.CreateMap<RestaurantDatabaseModel, RestaurantView>();

                //Add more mappings as needed
            });

            _mapper = config.CreateMapper();
        }

        public static TDestination Map<TSource, TDestination>(this TSource from)
        {
            return _mapper.Map<TDestination>(from);
        }
        public static List<TDestination> Map<TSource, TDestination>(this List<TSource> fromList)
        {
            return _mapper.Map<List<TDestination>>(fromList);
        }
    }
}