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
        public override int SaveChanges()
        {
            var entires = ChangeTracker.Entries<BaseEntity>();
            foreach(var entry in entires)
            {
                var entity=entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreationTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Modified:
                        entity.UpdateTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Deleted:
                        entity.UpdateTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Detached:
                        entity.UpdateTime = DateTime.UtcNow.AddHours(4);
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ServiceConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
