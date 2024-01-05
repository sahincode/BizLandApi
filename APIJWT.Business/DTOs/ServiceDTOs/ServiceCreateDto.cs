using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.ServiceDTOs
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
    }
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(s => s.Desc).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(300).WithMessage("Can not be greater than 300 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(s => s.Icon).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
        }
    }
}
