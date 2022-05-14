using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Business.Models.Results.Bases
{
public  interface IResultData< out TResultType>
    {
        TResultType Data { get; }
    }
}
