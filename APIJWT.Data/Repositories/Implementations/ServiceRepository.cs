using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using APIJWT.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Data.Repositories.Implementations
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
