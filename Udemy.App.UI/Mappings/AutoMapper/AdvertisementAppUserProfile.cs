using AutoMapper;
using Udemy.App.Dtos;
using Udemy.App.UI.Model;

namespace Udemy.App.UI.Mappings.AutoMapper
{
    public class AdvertisementAppUserProfile : Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUserCreateModel, AdvertisementAppUserCreateDto>().ReverseMap();
     
        }
    }
}
