using APIJWT.Business.DTOs.CategoryDTOs;
using APIJWT.Business.DTOs.PortfolioDTOs;
using APIJWT.Business.DTOs.ProfessionDTOs;
using APIJWT.Business.DTOs.ServiceDTOs;
using APIJWT.Business.DTOs.WorkerDTOs;
using APIJWT.Core.Models;
using AutoMapper;
using AutoMapper.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Profiles
{
    public  class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //service model mapping  profiles
            CreateMap<ServiceCreateDto, Service>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();
            CreateMap<ServiceGetDto, Service>().ReverseMap();
            //worker model mapping  profiles
            CreateMap<WorkerCreateDto, Worker>().ReverseMap();
            CreateMap<WorkerGetDto, Worker>().ReverseMap();
            CreateMap<WorkerUpdateDto, Worker>().ReverseMap();

            //profession model mapping  profiles
            CreateMap<ProfessionCreateDto, Profession>().ReverseMap();
            CreateMap<ProfessionGetDto, Profession>().ReverseMap();
            CreateMap<ProfessionUpdateDto, Profession>().ReverseMap();
            //category model mapping  profiles
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryGetDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            //portfolio model mapping  profiles
            CreateMap<PortfolioCreateDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioGetDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioUpdateDto, Portfolio>().ReverseMap();
        }
    }
}
