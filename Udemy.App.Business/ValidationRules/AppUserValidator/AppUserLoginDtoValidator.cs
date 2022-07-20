﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Dtos;

namespace Udemy.App.Business.ValidationRules
{
	public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
	{
		public AppUserLoginDtoValidator()
		{
			RuleFor(x => x.Username).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
