using AutoMapper;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Mappings.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GenderCreateDto, Gender>().ReverseMap();
            CreateMap<GenderUpdateDto, Gender>().ReverseMap();
            CreateMap<GenderListDto, Gender>().ReverseMap();
        }
    }
}
