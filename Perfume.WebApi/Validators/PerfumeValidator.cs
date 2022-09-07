
using FluentValidation;
using Perfume.ApplicationCore.DTOs;
using Perfume.ApplicationCore.Entities;

namespace Perfume.WebApi.Validators
{
    public class PerfumeValidator : AbstractValidator<CreatePerfumeRequest> 
    {
        public PerfumeValidator()
        {

            RuleFor(perfumee => perfumee.Name).NotNull().NotEmpty().Length(1, 250).WithMessage("Please add a Name");

            RuleFor(perfumee => perfumee.Brand).NotNull().NotEmpty().Length(1, 250).WithMessage("Please add a Brand");
        }
    }
}
