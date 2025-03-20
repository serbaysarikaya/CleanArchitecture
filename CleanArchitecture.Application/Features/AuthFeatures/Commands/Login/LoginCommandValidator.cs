using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
  public sealed class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {

            RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı ya da mail bilgisi boş olamaz");
            RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı ya da mail bilgisi boş olamaz");
            RuleFor(p => p.UserNameOrEmail).MinimumLength(5).WithMessage("Kullanıcı adı ya da mail bilgisi en az 5 karaterli olamalı");


            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az Bir büyük harf içermeldir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az Bir küçük harf içermeldir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az Bir adet rakam içermelidir");
            RuleFor(p => p.Password).Matches("^[a-zA-Z0-9]").WithMessage("Şifre en az Bir adet özel karakter içermelidir ");


        }
    }
}
