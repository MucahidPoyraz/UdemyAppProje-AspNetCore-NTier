﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Dtos;
using Udemy.App.Entities;

namespace Udemy.App.Business.Mappings.AutoMapper
{
	public class MilitaryStatusProfile : Profile
	{
		public MilitaryStatusProfile()
		{
			CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
		}
	}
}
