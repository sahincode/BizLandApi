using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.OperationExceptions
{
    public  class InvalidRegisterException :Exception
    {
        public InvalidRegisterException(){}
        public InvalidRegisterException(string message) : base(message) { }
    }
}
