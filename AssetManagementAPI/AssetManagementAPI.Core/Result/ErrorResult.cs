using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementAPI.Core.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult(Exception exception, string message) : base(false, message, exception)
        {

        }
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
