using System;
using System.Collections.Generic;
using System.Text;

namespace Udemy.App.Common
{
    public  class Response<T> : Response , IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidatonError> ValidationError { get; set; }
        public Response(ResponseType responseType,string message) : base(responseType,message)
        {

        }

        public Response(ResponseType responseType,T data) : base(responseType)
        {
            Data = data;
        }

        public Response( T data,List<CustomValidatonError> errors) : base(ResponseType.ValidationError)
        {
            ValidationError = errors;
            Data = data;
        }
    }
}
