﻿using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultArchitecture.Validators
{
    public class RegisterUserValidation : AbstractValidator<User>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid E-mail");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("The username cannot be null or empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6).WithMessage("The password cannot be null/empty and must have at least 6 characters");
        }
    }
}
