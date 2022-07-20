using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Udemy.App.UI.Model
{
    public class UserCreateModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Passwords { get; set; }
        public string ConfirmPasswords { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public SelectList Genders{ get; set; }

    }
}
