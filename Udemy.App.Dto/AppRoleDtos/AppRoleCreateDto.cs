using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Dtos.İnterfaces;

namespace Udemy.App.Dtos
{
    public class AppRoleCreateDto : IDto
    {     
        public string Definition { get; set; }
    }
}
