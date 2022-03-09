using AutoMapper;
using TrackerBar_Admin.API.DomainModels;
using DataModels = TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Direction, Direction>()
                .ReverseMap();

            CreateMap<DataModels.Phone, Phone>()
                .ReverseMap();
            
            CreateMap<DataModels.Receipt, Receipt>()
                            .ReverseMap();

            CreateMap<DataModels.ReceiptDetail, ReceiptDetail>()
                .ReverseMap();

            CreateMap<DataModels.Restaurant, Restaurant>()
                .ReverseMap();

            CreateMap<DataModels.RestaurantDirection, RestaurantDirection>()
                .ReverseMap();

            CreateMap<DataModels.User, User>()
                .ReverseMap();
        }
    }
}
