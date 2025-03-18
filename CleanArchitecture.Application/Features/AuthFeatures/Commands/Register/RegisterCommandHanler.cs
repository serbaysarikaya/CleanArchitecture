using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandHanler : IRequestHandler<RegisterCommand, MessageResponse>
    {
        private readonly IAuthService _authService;
        public RegisterCommandHanler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.ReqisterAsync(request);
            return new("User Registered Successfully");
        }
    }
}
