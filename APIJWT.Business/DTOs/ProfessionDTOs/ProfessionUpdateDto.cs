using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.ProfessionDTOs
{
    public class ProfessionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
    public class ProfessionUpdateDtoValidator : AbstractValidator<ProfessionUpdateDto>
    {
        public ProfessionUpdateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                    MinimumLength(2).WithMessage("Can not be less than 5 digits");
            
        }
    }
}
        