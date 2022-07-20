using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceListDto, ProvidedServices>().ReverseMap();
        }
    }
}
