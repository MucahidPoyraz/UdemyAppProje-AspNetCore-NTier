using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Business.Extensions;
using Udemy.App.Business.İnterfaces;
using Udemy.App.Common;
using Udemy.App.Common.Enums;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _validator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> validator, IMapper mapper)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsyncBl(AdvertisementAppUserCreateDto dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsyncDal(x => x.AppUserId == dto.AppUserId && x.AddvertisementId == dto.AddvertisementId);

                if (control == null)
                {
                    var createAdvertismentAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsyncDal(createAdvertismentAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Succes, dto);
                }

                List<CustomValidatonError> errors = new List<CustomValidatonError>
                {
                    new CustomValidatonError
                    {
                        ErrorMessage = "Zaten bir başvuru yapılmış.",
                        PropertyName = "",
                    }
                };
                return new Response<AdvertisementAppUserCreateDto>(dto, errors);

            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQueryDal();
            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();
            var dto = _mapper.Map<List<AdvertisementAppUserListDto>>(list);
            return dto;
        }

        public async Task SetStatusAsyncBl(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            //var unchanged = await _uow.GetRepository<AdvertisementAppUser>().FindAsyncDal(advertisementAppUserId);
            //_uow.GetRepository<AdvertisementAppUser>().UpdateDal(new AdvertisementAppUser{MilitaryStatusId = (int)type }, unchanged); 

            var query = _uow.GetRepository<AdvertisementAppUser>().GetQueryDal();

            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();

        }
    }
}

