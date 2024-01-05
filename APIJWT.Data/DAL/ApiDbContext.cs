using APIJWT.Core.Configurations;
using APIJWT.Core.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Data.DAL
{
    public  class ApiDbContext :IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) :base(options){}
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ServiceConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
