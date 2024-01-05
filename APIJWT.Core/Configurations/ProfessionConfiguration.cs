using APIJWT.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Core.Configurations
{
    public class ProfessionConfiguration
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(30);
        }
    }
}
