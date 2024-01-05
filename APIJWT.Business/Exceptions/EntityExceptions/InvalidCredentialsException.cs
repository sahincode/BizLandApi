using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.EntityExceptions
{
    public class InvalidCredentialsException :Exception
    {
        public InvalidCredentialsException(){}
        public InvalidCredentialsException(string message):base(message) { }

    }
}
