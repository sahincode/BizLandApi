
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
