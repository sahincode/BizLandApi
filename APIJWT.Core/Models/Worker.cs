
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Models
{
    public class Worker : BaseEntity
    {
        public string FullName { get; set; }
        public string MediaUrl { get; set; }
        public Profession Profession { get; set; }
        public int ProfessionId { get; set; }

        public string ImageUrl { get; set; }

    }
}
