var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Assembyl refers to the CleanArchitecture.Presentation project
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CleanArchitecture.WebApi", Version = "v1" });
});



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
