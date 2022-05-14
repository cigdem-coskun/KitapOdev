using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Business.Models.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult( string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false,"")
        {

        }
      
        }

    public class ErrorResult<TResultType> : Result<TResultType>
    {
        public ErrorResult(string message, TResultType data) : base(false, message, data)
        {
        }

        public ErrorResult(string message) : base(false, message, default)
        {
        }

        public ErrorResult() : base(false, "", default)
        {
        }
    }
}
