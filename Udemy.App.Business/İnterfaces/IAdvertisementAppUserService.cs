using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Common;
using Udemy.App.Common.Enums;
using Udemy.App.Dtos;

namespace Udemy.App.Business.İnterfaces
{
	public interface IAdvertisementAppUserService
	{
		Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsyncBl(AdvertisementAppUserCreateDto dto);
		Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
		Task SetStatusAsyncBl(int advertisementAppUserId, AdvertisementAppUserStatusType type);
	}
}
