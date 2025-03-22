using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole
{
   public sealed class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim alanı en az üç karakter olmalıdır.");
        }
    }
}
