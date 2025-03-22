using FluentValidation;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public sealed class CreateUserRoleCommandValidator: AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı bilgileri boş olamaz.");
            RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı bilgileri boş olamaz.");

            RuleFor(p => p.RoleId).NotEmpty().WithMessage("Kullanıcı role bilgileri boş olamaz.");
            RuleFor(p => p.RoleId).NotNull().WithMessage("Kullanıcı role bilgileri boş olamaz.");
        }
    }
}
