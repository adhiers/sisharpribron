using System;
using Microsoft.Extensions.DependencyInjection;
using sisharpriborn.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace sisharpriborn.DAL.Extensions;

public static class DataAccessLayerServiceExtensions
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ICar, CarDAL>();
        // Register the DealerCarDAL service
        services.AddScoped<IDealer, DealerDAL>();
        services.AddScoped<IDealerCar, DealerCarDAL>();

        // Register the DealerDAL service

        // Add other DAL services as needed

        return services;
    }   
}
