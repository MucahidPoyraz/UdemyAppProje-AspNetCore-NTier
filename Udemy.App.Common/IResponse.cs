using System;
using System.Collections.Generic;
using System.Text;

namespace Udemy.App.Common
{
    public interface IResponse
    {
         string Message { get; set; }
         ResponseType ResponseType { get; set; }
    }
}
