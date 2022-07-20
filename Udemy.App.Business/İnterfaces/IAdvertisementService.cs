using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.App.Common;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.İnterfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsyncBl();
    }
}
