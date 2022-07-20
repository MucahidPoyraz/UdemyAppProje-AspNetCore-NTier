using AutoMapper;
using FluentValidation;
using Udemy.App.Business.İnterfaces;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
