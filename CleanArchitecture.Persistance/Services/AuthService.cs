﻿using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null) throw new Exception("Kullanıcı Bulunamadı");

            if (request.RefreshToken != request.RefreshToken) throw new Exception("Refresh token gecerli değildir.");

            if(user.RefreshTokenExpires<DateTime.Now)
                throw new Exception("Refresh token süresi dolmuştur");

            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);

            return response;
        }



        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userManager.Users
                                      .Where(
                                             p => p.UserName == request.UserNameOrEmail
                                               || p.Email == request.UserNameOrEmail)
                                      .FirstOrDefaultAsync(cancellationToken);

            if (user == null) throw new Exception("Kullanıcı Bulunamadı");

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (result)
            {
                LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }

            throw new Exception("Kullanıcı Adı veya Şifre Hatalı");

        }

        public async Task ReqisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);

            }
            List<string> emails = new List<string>();
            emails.Add(request.Email);
            string body = "Mail Onayı İçin Tıklayınız";
            await _mailService.SendMailAsync(emails, "Mail Onayı", body, null);
        }
    }
}
