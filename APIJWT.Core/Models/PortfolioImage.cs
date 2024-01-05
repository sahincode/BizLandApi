using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Models
{
    public class PortfolioImage : BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool IsPoster { get; set; }
        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
