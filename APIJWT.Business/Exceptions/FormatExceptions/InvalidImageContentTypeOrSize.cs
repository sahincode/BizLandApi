using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Exceptions.FormatExceptions
{
    public class InvalidImageContentTypeOrSize :Exception
    {
        public InvalidImageContentTypeOrSize(){}
        public InvalidImageContentTypeOrSize( string message):base(message) { }

    }
}
