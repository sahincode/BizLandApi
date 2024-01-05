using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.ProfessionDTOs
{
    public  class ProfessionGetDto
    { 
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Name { get; set; }
        
    }
}
