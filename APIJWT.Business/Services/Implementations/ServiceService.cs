using APIJWT.Business.DTOs.ServiceDTOs;
using APIJWT.Business.Exceptions.EntityExceptions;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _service;

        public ServiceService(IMapper mapper, IServiceRepository service)
        {
            this._mapper = mapper;
            this._service = service;
        }
        public async Task CreateAsync(ServiceCreateDto entity)
        {
            Service about = _mapper.Map<Service>(entity);
            await _service.CreateAsync(about);
            await _service.CommitChange();


        }

        public async Task Delete(int id)
        {
            var service = await _service.Get(a => a.Id == id);
            if (service == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _service.Delete(service);


        }

        public async Task<Service> Get(Expression<Func<Service, bool>>? predicate, params string[]? includes)
        {
            return await _service.Get(predicate, includes) is not null ?
                 await _service.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        

        public async Task<IEnumerable<Service>> GetAll(Expression<Func<Service, bool>>? predicate, params string[]? includes)
        {
            return await _service.GetAll(predicate, includes) is not null ?
                await _service.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public Task<IEnumerable<Service>> GetAll(Expression<Func<Service>>? expression, params string[]? includes)
        {
            throw new NotImplementedException();
        }

        public async Task<Service> GetByIdAsync(int? id)
        {
            return await _service.Get(a => a.Id == id);
        }

       

        public async Task ToggleDelete(int id)
        {
            var service = await this.GetByIdAsync(id);
            if (service == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            service.IsDeleted = !service.IsDeleted;
            await _service.CommitChange();

        }

        public async Task UpdateAsync(int? id, ServiceUpdateDto entity)
        {

            var updatedService = await _service.Get(a => a.Id == id);
            if (updatedService == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedService = _mapper.Map(entity, updatedService);

            await _service.CommitChange();

        }

   
    }
}
