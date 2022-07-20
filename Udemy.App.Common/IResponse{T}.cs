using System;
using System.Collections.Generic;
using System.Text;

namespace Udemy.App.Common
{
    public interface IResponse<T> : IResponse
    {
         T Data { get; set; }
         List<CustomValidatonError> ValidationError { get; set; }
    }
}
