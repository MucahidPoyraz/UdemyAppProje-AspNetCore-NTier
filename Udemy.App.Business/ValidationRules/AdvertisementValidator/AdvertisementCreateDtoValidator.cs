using FluentValidation;
using Udemy.App.Dtos;

namespace Udemy.App.Business.ValidationRules
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
           
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();

        }
    }
}
