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
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(prop => prop.FullName).IsRequired().HasMaxLength(30);
            builder.Property(prop => prop.MediaUrl).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.ImageUrl).IsRequired().HasMaxLength(100);
        }
    }
}
