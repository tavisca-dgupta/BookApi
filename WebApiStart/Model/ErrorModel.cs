using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStart.Errors
{
    public class ErrorModel
    {
        public ErrorModel(int code,string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public int Code { get; private set; }
        public string Message { get; private set; }
    }
}
