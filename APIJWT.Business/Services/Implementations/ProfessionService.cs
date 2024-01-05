using APIJWT.Business.DTOs.ProfessionDTOs;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Implementations
{
    public  class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync([FromForm] ProfessionCreateDto professionCreateDto)
        {
            Profession profession = _mapper.Map<Profession>(professionCreateDto);
            profession.IsDeleted = false;

            await _professionRepository.CreateAsync(profession);
            await _professionRepository.CommitChange();
        }

        public async Task DeleteAsync(int id)
        {
            Profession profession = await _professionRepository.Get(feature => feature.Id == id);

            if (profession == null) throw new NullReferenceException("profession couldn't be null!");

            _professionRepository.Delete(profession);
            await _professionRepository.CommitChange();
        }

        public async  Task<Profession> Get(Expression<Func<Profession, bool>>? predicate, params string[]? includes)
        {
            Profession profession = await _professionRepository.Get(predicate ,includes);

            if (profession == null) throw new NullReferenceException("profession couldn't be null!");

            

            return profession;

        }

        public async Task<IEnumerable<ProfessionGetDto>> GetAllAsync(Expression<Func<Profession, bool>>? predicate, params string[]? includes)
        {
            IEnumerable<Profession> professions = await _professionRepository.GetAll(predicate , includes);

            if (professions == null) throw new NullReferenceException("professions couldn't be null!");

            IEnumerable<ProfessionGetDto> professionGetDtos = professions.Select(profession => new ProfessionGetDto { Name = profession.Name, Id = profession.Id });

            return professionGetDtos;
        }

        public async Task<ProfessionGetDto> GetByIdAsync(int id)
        {
            Profession profession = await _professionRepository.Get(profession => profession.Id == id);

            if (profession == null) throw new NullReferenceException("profession couldn't be null!");

            ProfessionGetDto professionGetDto = _mapper.Map<ProfessionGetDto>(profession);

            return professionGetDto;
        }

        public async Task ToggleDelete(int id)
        {
            Profession profession = await _professionRepository.Get(profession => profession.Id == id);

            if (profession == null) throw new NullReferenceException("profession couldn't be null!");

            profession.IsDeleted = !profession.IsDeleted;
           

            await _professionRepository.CommitChange();
        }

        public async Task UpdateAsync([FromForm] ProfessionUpdateDto professionUpdateDto)
        {
            Profession profession = await _professionRepository.Get(profession => profession.Id == professionUpdateDto.Id);

            if (profession == null) throw new NullReferenceException("profession couldn't be null!");

            profession = _mapper.Map(professionUpdateDto, profession);
           

            await _professionRepository.CommitChange();
        }

       
    }
}
