using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
 public sealed   class CreateNewTokenByRefreshTokenCommandValidator:AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenCommandValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("User bilgisi Boş olamaz.");
            RuleFor(p => p.UserId).NotNull().WithMessage("User bilgisi Boş olamaz.");

            RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refreh token bilgisi boş olamaz.");
            RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refreh token bilgisi boş olamaz.");
        }
    }
}
