using AutoMapper;
using FluentValidation;
using Udemy.App.Business.İnterfaces;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedServices>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
