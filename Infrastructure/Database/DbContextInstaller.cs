﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Database
{
    public static class DbContextInstaller
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")) , ServiceLifetime.Scoped);
            services.AddScoped<DbContext>(provider => provider.GetService<AppDbContext>()!);

            return services;
        }
    }
}
