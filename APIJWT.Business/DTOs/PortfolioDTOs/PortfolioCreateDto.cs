﻿
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.PortfolioDTOs
{
    public class PortfolioCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectUrl { get; set; }
        public string Client { get; set; }
        public DateTime ProjectDate { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> PortfolioSlideImages { get; set; }
        public IFormFile PortfolioItemImage { get; set; }
    }
}
