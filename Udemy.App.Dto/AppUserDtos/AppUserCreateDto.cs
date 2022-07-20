using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Dtos.İnterfaces;

namespace Udemy.App.Dtos
{
    public class AppUserCreateDto : IDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Passwords { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
    }
}
