using APIJWT.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Configurations
{
    public class PortfolioImageConfiguration : IEntityTypeConfiguration<PortfolioImage>
    {
        public void Configure(EntityTypeBuilder<PortfolioImage> builder)
        {
            builder.Property(prop => prop.ImgUrl).IsRequired().HasMaxLength(100);
        }
    }
}
