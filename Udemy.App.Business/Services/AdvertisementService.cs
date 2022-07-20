using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.App.Business.İnterfaces;
using Udemy.App.Common;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsyncBl()
        {
           var data =await _uow.GetRepository<Advertisement>().GetAllAsyncDal(x => x.Status, x => x.CreateTime, Common.Enums.OrderbyType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Succes, dto);
        }
    }
}
