using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.EntityExceptions
{
    public class EntityExistException :Exception
    {
        public EntityExistException(){}
        public EntityExistException( string message):base(message){}
    }
}
