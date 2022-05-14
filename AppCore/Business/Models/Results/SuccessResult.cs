using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Business.Models.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult( string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true,"")
        {

        }
    }

    public class SuccessResult<TResultType> : Result<TResultType>
    {
        public SuccessResult( string message, TResultType data) : base(true, message, data)
        {
        }

        public SuccessResult(string message) : base(true, message,default)
        {
        }

        public SuccessResult() : base(true, "", default)
        {
        }
    }
}
