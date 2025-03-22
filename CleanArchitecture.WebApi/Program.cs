using CleanArchitecture.WebApi.Configurations;
using CleanArchitecture.WebApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallService(builder.Configuration,builder.Host, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.WebApi v1"));
}

app.UseCors();

app.MiddlewareExtensions();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
