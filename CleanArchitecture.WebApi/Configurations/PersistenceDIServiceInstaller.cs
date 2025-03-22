
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middleware;
using GenericRepository;

namespace CleanArchitecture.WebApi.Configurations
{
    public sealed class PersistenceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
