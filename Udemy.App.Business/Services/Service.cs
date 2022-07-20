using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Business.Extensions;
using Udemy.App.Business.İnterfaces;
using Udemy.App.Common;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos.İnterfaces;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsyncBl(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsyncDal(createdEntity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Succes, dto);
            }
            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsyncBl()
        {
            var data = await _uow.GetRepository<T>().GetAllAsyncDal();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Succes, dto);
        }

        public async Task<IResponse<IDto>> GetByIdAsnycBl<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsyncDal(x => x.Id == id);
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ' idsine ait data bulunamadı.");
            }
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Succes, dto);
        }

        public async Task<IResponse> RemoveAsnycBl(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsyncDal(id);
            if (data == null)
            {
                return new Response(ResponseType.NotFound, $"{id} ' idsine ait data bulunamadı.");
            }
            _uow.GetRepository<T>().RemoveDal(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Succes);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsyncBl(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepository<T>().FindAsyncDal(dto.Id);
                if (unchangedData == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} ' idsine ait data bulunamadı.");
                }
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().UpdateDal(entity, unchangedData);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Succes, dto);
            }
            return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());

        }
    }
}
