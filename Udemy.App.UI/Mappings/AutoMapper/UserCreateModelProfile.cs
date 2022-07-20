﻿using AutoMapper;
using Udemy.App.Dtos;
using Udemy.App.UI.Model;

namespace Udemy.App.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}