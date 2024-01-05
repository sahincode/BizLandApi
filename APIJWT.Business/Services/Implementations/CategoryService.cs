
using APIJWT.Business.DTOs.CategoryDTOs;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using APIJWT.Core.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace APIJWT.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync([FromForm] CategoryCreateDto categoryCreateDto)
        {
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.IsDeleted = false;

            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.CommitChange();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.Get(category => category.Id == id);

            if (category == null) throw new NullReferenceException("category couldn't be null!");

            _categoryRepository.Delete(category);
            await _categoryRepository.CommitChange();
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAll(category => category.IsDeleted == false);

            if (categories == null) throw new NullReferenceException("categories couldn't be null!");

            IEnumerable<CategoryGetDto> categoryGetDtos = categories.Select(category => new CategoryGetDto { Id = category.Id, Name = category.Name });

            return categoryGetDtos;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.Get(category => category.Id == id);

            if (category == null) throw new NullReferenceException("category couldn't be null!");

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }


        public async Task ToggleDelete(int id)
        {
            Category category = await _categoryRepository.Get(category => category.Id == id);

            if (category == null) throw new NullReferenceException("category couldn't be null!");

            category.IsDeleted = !category.IsDeleted;
           

            await _categoryRepository.CommitChange();
        }

        public async Task UpdateAsync([FromForm] CategoryUpdateDto categoryUpdateDto)
        {
            Category category = await _categoryRepository.Get(category => category.Id == categoryUpdateDto.Id);

            if (category == null) throw new NullReferenceException("feature couldn't be null!");


            category = _mapper.Map(categoryUpdateDto, category);
            await _categoryRepository.CommitChange();
        }
    }
}
