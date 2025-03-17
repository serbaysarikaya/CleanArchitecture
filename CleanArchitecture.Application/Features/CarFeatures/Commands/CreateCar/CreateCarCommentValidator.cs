using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public sealed class CreateCarCommentValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommentValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Araç adı boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Araç adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Arac adı en az 3 karakter uzunluğunda olmalıdır.");

            RuleFor(p => p.Model).NotEmpty().WithMessage("Model adı boş olamaz");
            RuleFor(p => p.Model).NotNull().WithMessage("Model adı boş olamaz");
            RuleFor(p => p.Model).MinimumLength(3).WithMessage("Arac Modeli en az 3 karakter uzunluğunda olmalıdır.");

            RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Motor gücü boş olamaz");
            RuleFor(p => p.Model).NotNull().WithMessage("Motor gücü  boş olamaz");
            RuleFor(p=>p.EnginePower).GreaterThan(0).WithMessage("Motor gücü 0'dan büyük olmalıdır.");
        }
    }
}
