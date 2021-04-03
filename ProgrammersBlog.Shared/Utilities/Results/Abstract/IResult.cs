using ProgrammersBlog.Shared.Utilities.Results.Complex_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
   public interface IResult
    {
       
        public ResultStatus ResultStatus { get; }
        public string Message { get;}
        public Exception Exception { get; }
    }
}
