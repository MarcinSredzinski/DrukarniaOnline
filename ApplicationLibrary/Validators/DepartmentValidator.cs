using CoreLibrary.Entities.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLibrary.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().Length(2, 50)
                .WithMessage("{PropertyName} ma niewłaściwą długość znaków: ({TotalLength})");

        }
    }
}
