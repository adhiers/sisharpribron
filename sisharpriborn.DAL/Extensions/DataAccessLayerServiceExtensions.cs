using System;
using Microsoft.Extensions.DependencyInjection;
using sisharpriborn.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace sisharpriborn.DAL.Extensions;

public static class DataAccessLayerServiceExtensions
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        // Add Entity Framework
        services.AddDbContext<FinalProjectContext>(options =>
            options.UseSqlServer(services.BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString("FinalProjectConnectionString")));
        

        services.AddIdentityCore<IdentityUser>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }).AddRoles<IdentityRole>().AddEntityFrameworkStores<FinalProjectContext>();

        services.AddScoped<ICar, CarDAL>();
        services.AddScoped<IDealer, DealerDAL>();   
        services.AddScoped<IDealerCar, DealerCarDAL>();
        services.AddScoped<IUsman, UsmanDAL>();

        return services;
    }   
}
