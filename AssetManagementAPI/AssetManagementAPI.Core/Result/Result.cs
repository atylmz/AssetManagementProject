using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Core.Result
{
    public class Result : IResult
    {
        public Result(bool success, string message, Exception ex) : this(success, message)
        {
            exception = ex;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }

        public Exception exception { get; }
    }
}
