using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.App.Business.Extensions;
using Udemy.App.Business.İnterfaces;
using Udemy.App.Common;
using Udemy.App.DataAccess.UnitOfWork;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsyncBl(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                //1.Yöntem 

                //user.AppUserRoles = new List<AppUserRole>();
                //user.AppUserRoles.Add(new AppUserRole
                //{
                //    AppUser = user,
                //    AppRoleId = roleId
                //});

                await _uow.GetRepository<AppUser>().CreateAsyncDal(user);

                //2.Yöntem

                await _uow.GetRepository<AppUserRole>().CreateAsyncDal(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId,
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Succes, dto);
            }

            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());



        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsyncBl(AppUserLoginDto dto)
        {
            var validatorResult = _loginDtoValidator.Validate(dto);
            if (validatorResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsyncDal(x => x.UserName == dto.Username && x.Passwords == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Succes, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kulllanıcı yada parola yanlış!");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kulllanıcı yada parola alanı boş geçmeyiniz.");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsyncBl(int userId)
        {
           var roles = await _uow.GetRepository<AppRole>().GetAllAsyncDal(x=>x.AppUserRoles.Any(x=>x.AppUserId == userId));
			if (roles == null)
			{
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunamadı");
			}
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Succes, dto);
        } 
    }
}
