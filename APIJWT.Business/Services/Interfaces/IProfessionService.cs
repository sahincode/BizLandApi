using APIJWT.Business.DTOs.ProfessionDTOs;
using APIJWT.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Interfaces
{
    public  interface IProfessionService
    {
        Task CreateAsync([FromForm] ProfessionCreateDto professionCreateDto);
        Task UpdateAsync([FromForm] ProfessionUpdateDto professionUpdateDto);
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
        Task<ProfessionGetDto> GetByIdAsync(int id);
        public Task<Profession> Get(Expression<Func<Profession, bool>>? predicate, params string[]? includes);
        public Task<IEnumerable<ProfessionGetDto>> GetAllAsync(Expression<Func<Profession, bool>>? predicate, params string[]? includes);

    }
}
