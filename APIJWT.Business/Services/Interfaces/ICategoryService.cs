
using APIJWT.Business.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync([FromForm] CategoryCreateDto categoryCreateDto);
        Task UpdateAsync([FromForm] CategoryUpdateDto categoryUpdateDto);
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryGetDto>> GetAllAsync();
    }
}
