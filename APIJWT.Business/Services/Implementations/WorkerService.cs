using APIJWT.Business.Asistants;
using APIJWT.Business.DTOs.WorkerDTOs;
using APIJWT.Business.Exceptions.FormatExceptions;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Implementations
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public WorkerService(IWorkerRepository workerRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync([FromForm] WorkerCreateDto workerCreateDto)
        {
            if (workerCreateDto.ImgFile != null)
            {
                if (workerCreateDto.ImgFile.ContentType != "image/png" && workerCreateDto.ImgFile.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSize("enter the correct image ContentType!");
                }

                if (workerCreateDto.ImgFile.Length > 1048576)
                {
                    throw new InvalidImageContentTypeOrSize("image size must be less than 1mb!");
                }
            }
            else
            {
                throw new NullImageException("Image is required!");
            }

            string folder = "uploads/worker";
            string newImgUrl = await FileHelper.GetFileName(_env.WebRootPath, folder, workerCreateDto.ImgFile);

            Worker worker = _mapper.Map<Worker>(workerCreateDto);
            worker.ImageUrl = newImgUrl;

            await _workerRepository.CreateAsync(worker);
            await _workerRepository.CommitChange();
        }

        public async Task DeleteAsync(int id)
        {

            Worker worker = await _workerRepository.Get(worker => worker.Id == id);

            if (worker == null) throw new NullReferenceException("worker couldn't be null!");

            string folder = "uploads/worker";
            string fullPath = Path.Combine(_env.WebRootPath, folder, worker.ImageUrl);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _workerRepository.Delete(worker);
            await _workerRepository.CommitChange();
        }

        public async Task<IEnumerable<WorkerGetDto>> GetAllAsync()
        {
            IEnumerable<Worker> workers = await _workerRepository.GetAll(worker => worker.IsDeleted == false, "Profession");

            IEnumerable<WorkerGetDto> workerGetDtos = workers.Select(worker => new WorkerGetDto { FullName = worker.FullName, ImgUrl = worker.ImageUrl, Profession = worker.Profession.Name, MediaUrl = worker.MediaUrl, Id = worker.Id });

            return workerGetDtos;
        }

        public async Task<WorkerGetDto> GetByIdAsync(int id)
        {
            Worker worker = await _workerRepository.Get(worker => worker.Id == id, "Profession");

            if (worker == null) throw new NullReferenceException("worker couldn't be null!");

            WorkerGetDto workerGetDto = _mapper.Map<WorkerGetDto>(worker);
            workerGetDto.Profession = worker.Profession.Name;

            return workerGetDto;
        }

        public async Task ToggleDelete(int id)
        {

            Worker worker = await _workerRepository.Get(worker => worker.Id == id);

            if (worker == null) throw new NullReferenceException("worker couldn't be null!");

            worker.IsDeleted = !worker.IsDeleted;
           

            await _workerRepository.CommitChange();
        }

        public async Task UpdateAsync([FromForm] WorkerUpdateDto workerUpdateDto)
        {
            Worker worker = await _workerRepository.Get(worker => worker.Id == workerUpdateDto.Id);
            if (worker == null) throw new NullReferenceException("worker couldn't be null!");

            if (workerUpdateDto.ImgFile != null)
            {
                if (workerUpdateDto.ImgFile.ContentType != "image/png" && workerUpdateDto.ImgFile.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSize("enter the correct image contenttype!");
                }

                if (workerUpdateDto.ImgFile.Length > 1048576)
                {
                    throw new InvalidImageContentTypeOrSize("image size must be less than 1mb!");
                }

                string folder = "uploads/worker";
                string newImgUrl = await FileHelper.GetFileName(_env.WebRootPath, folder, workerUpdateDto.ImgFile);

                string oldImgPath = Path.Combine(_env.WebRootPath, folder, worker.ImageUrl);

                if (File.Exists(oldImgPath))
                {
                    File.Delete(oldImgPath);
                }
                worker.ImageUrl = newImgUrl;

            }
            worker = _mapper.Map(workerUpdateDto, worker);

            await _workerRepository.CommitChange();
        }
    }
}
