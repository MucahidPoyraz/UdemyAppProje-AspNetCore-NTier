using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.App.Common;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.İnterfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsyncBl(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUserAsyncBl(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsyncBl(int userId);
    }
}
