﻿using APIJWT.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(prop => prop.Title).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.Description).IsRequired().HasMaxLength(150);
            builder.Property(prop => prop.Client).IsRequired().HasMaxLength(30);
            builder.Property(prop => prop.ProjectUrl).IsRequired().HasMaxLength(50);
            
        }
    }
}
