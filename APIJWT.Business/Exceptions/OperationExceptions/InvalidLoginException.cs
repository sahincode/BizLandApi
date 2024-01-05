using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.OperationExceptions
{
    public  class InvalidLoginException :Exception
    {
        public InvalidLoginException() { }

        public InvalidLoginException(string message) :base(message){}
    }
}
