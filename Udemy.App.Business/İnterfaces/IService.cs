using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Common;
using Udemy.App.Dtos.İnterfaces;
using Udemy.App.Entities;

namespace Udemy.App.Business.İnterfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDto, new()
         where T :  BaseEntity
    { 
        Task<IResponse<CreateDto>> CreateAsyncBl(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsyncBl(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsnycBl<IDto>(int id);
        Task<IResponse> RemoveAsnycBl(int id);
        Task<IResponse<List<ListDto>>> GetAllAsyncBl();
    }
}
