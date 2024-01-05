using APIJWT.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Repositories.Interfaces
{
    public  interface IGenericRepository<TEntity> where TEntity:BaseEntity ,new()
    {
        public DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate, params string[] includes);
        Task<TEntity> Get(Expression<Func<TEntity, bool>>? predicate, params string[] includes);
        Task<int> CommitChange();

    }
}
