﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.DTOs.UserDTOs
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(s => s.Username).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                    MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(s => s.FullName).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   MaximumLength(50).WithMessage("Can not be greater than 50 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(s => s.Email).NotNull().WithMessage("Can not be null").
                                   NotEmpty().WithMessage("Can not be empty").
                                   EmailAddress().WithMessage("please fill valid email").
                                   MaximumLength(100).WithMessage("Can not be greater than 100 digits").
                                   MinimumLength(5).WithMessage("Can not be less than 5 digits");
            RuleFor(s => s.Password).NotNull().WithMessage("Can not be null").
                                    NotEmpty().WithMessage("Can not be empty").
                                    MaximumLength(30).WithMessage("Can not be greater than 30 digits").
                                    MinimumLength(8).WithMessage("Can not be less than 8 digits");
        }
    }
}

