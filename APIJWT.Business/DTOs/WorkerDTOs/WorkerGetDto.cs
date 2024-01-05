using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.WorkerDTOs
{
    public class WorkerGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MediaUrl { get; set; }
        public string Profession { get; set; }
        public string ImgUrl { get; set; }
    }
}
