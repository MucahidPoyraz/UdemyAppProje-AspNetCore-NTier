using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Common.Enums;
using Udemy.App.Dtos;

namespace Udemy.App.Business.ValidationRules
{
	public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
	{
		public AdvertisementAppUserCreateDtoValidator()
		{
			RuleFor(x => x.AppUserId).NotEmpty();
			RuleFor(x => x.AddvertisementId).NotEmpty();
			RuleFor(x => x.AppUserId).NotEmpty();
			RuleFor(x => x.CvPath).NotEmpty();
			RuleFor(x => x.EndDate).NotEmpty().When(x=>x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli);
			RuleFor(x => x.WorkExperience).NotEmpty();
		}
	}
}
