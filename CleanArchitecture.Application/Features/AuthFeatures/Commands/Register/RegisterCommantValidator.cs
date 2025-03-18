using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommantValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommantValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email boş olamaz");
            RuleFor(p => p.Email).NotNull().WithMessage("Email boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adres girin.");


            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.UserName).MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karaterli olamalı");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az Bir büyük harf içermeldir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az Bir küçük harf içermeldir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az Bir adet rakam içermelidir");
            RuleFor(p => p.Password).Matches("^[a-zA-Z0-9]").WithMessage("Şifre en az Bir adet özel karakter içermelidir ");
        }
    }

}