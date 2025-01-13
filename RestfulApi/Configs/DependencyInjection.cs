using ApplicationCore.BusinessLogic.Interfaces;
using ApplicationCore.BusinessLogic.Services;
using ApplicationCore.Handlers;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Base;
using Infrastructure.Database;
using Infrastructure.Repositories;
using MediatR;
namespace RestfulApi.Configs
{
    public static class DependencyInjection
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterRepositories()
                .RegisterDBContext(configuration)
                .RegisterMediatR()
                .AddCustomCors()
                .AddCustomServices();

            return services;
        }

        private static IServiceCollection RegisterDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseConfiguration(configuration); 
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Ajouter les contrôleurs
            services.AddControllers();

            // Ajouter l'exploration des points de terminaison API
            services.AddEndpointsApiExplorer();

            // Ajouter Swagger
            services.AddSwaggerGen();

            return services;
        }

        private static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreatePersonCommandHandler).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly);
            });

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowAnyOrigin();
                });
            });

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
