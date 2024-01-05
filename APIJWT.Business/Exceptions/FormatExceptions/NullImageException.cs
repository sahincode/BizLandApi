using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.FormatExceptions
{
    public  class NullImageException : Exception
    {
        public NullImageException(){}
        public NullImageException(string message):base(message) { }

    }
}
