using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Models
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
    }
}
