using APIJWT.Business.DTOs.ProfessionDTOs;
using APIJWT.Business.DTOs.ServiceDTOs;
using APIJWT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Interfaces
{
    public  interface IServiceService
    {
        public Task CreateAsync(ServiceCreateDto entity);
        public Task UpdateAsync(int ? id ,ServiceUpdateDto entity);
        public Task ToggleDelete(int id);
        public Task Delete(int id);
        public Task<Service> GetByIdAsync(int ? id);
        public Task<Service> Get(Expression<Func<Service,bool>> ? predicate ,params string[] ? includes);
        public Task<IEnumerable<Service>> GetAll(Expression<Func<Service,bool>>? predicate, params string[]? includes);


    }
}
