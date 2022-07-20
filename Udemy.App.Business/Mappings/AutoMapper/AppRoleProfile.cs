using AutoMapper;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Mappings.AutoMapper
{
	public class AppRoleProfile : Profile
	{
		public AppRoleProfile()
		{
			CreateMap<AppRole, AppRoleListDto>().ReverseMap();
		}
	}
}
