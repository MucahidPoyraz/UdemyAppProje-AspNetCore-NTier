using FluentValidation;
using System;
using Udemy.App.UI.Model;

namespace Udemy.App.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
       
        public UserCreateModelValidator()
        {
            
            RuleFor(x => x.Passwords).NotEmpty();
            RuleFor(x => x.Passwords).MinimumLength(3);
            RuleFor(x => x.Passwords).Equal(x=>x.ConfirmPasswords).WithMessage("Password not match");
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).MinimumLength(3);
            RuleFor(x => new
            {
                x.UserName,
                x.Firstname,
            }).Must(x=> CanNotFirstname(x.UserName, x.Firstname)).WithMessage("username contains firstname!").When(x=>x.UserName != null && x.Firstname !=null);

            RuleFor(x => x.GenderId).NotEmpty();
           
          
        }

        private bool CanNotFirstname(string username, string firstname)
        {
           return !username.Contains(firstname);
        }
    }
}
