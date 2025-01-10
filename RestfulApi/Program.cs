using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Serilog;
using ApplicationCore.Base;
using ApplicationCore.BusinessLogic.Interfaces;
using ApplicationCore.BusinessLogic.Services;
using ApplicationCore.Commands;
using ApplicationCore.Queries;
using System.Reflection;
using ApplicationCore.Handlers;
using Domain.Models;
using Infrastructure.Base;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la base de données
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Enregistrement des dépendances
builder.Services.AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
builder.Services.AddScoped<IPersonService, PersonService>();

// Configuration de MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
});

// Ajout des contrôleurs et de Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Configuration de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Middlewares pour le développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
