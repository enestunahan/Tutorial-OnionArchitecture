using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;
using Service;
using Service.Contracts;
using Tutorial_OnionArchitecture.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();

builder.Services.ConfigureSqlDbContext(builder.Configuration);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddSingleton<ILoggerManager,LoggerManager>();
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

//Bende bu uygulamanýn bir parçasýyým anlamýna geliyor
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Tutorial_OnionArchitecture.Presentation.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
