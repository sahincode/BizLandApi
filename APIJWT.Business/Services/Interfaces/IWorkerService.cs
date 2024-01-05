
using APIJWT.Business.DTOs.WorkerDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Interfaces
{
    public interface IWorkerService
    {
        Task CreateAsync([FromForm] WorkerCreateDto workerCreateDto);
        Task UpdateAsync([FromForm] WorkerUpdateDto workerUpdateDto);
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
        Task<WorkerGetDto> GetByIdAsync(int id);
        Task<IEnumerable<WorkerGetDto>> GetAllAsync();
    }
}
