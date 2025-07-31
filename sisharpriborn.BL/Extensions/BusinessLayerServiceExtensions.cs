    using System;
    using sisharpriborn.BL;
    using sisharpriborn.DAL; 
    using sisharpriborn.DAL.Extensions;
    using Microsoft.Extensions.DependencyInjection;

namespace sisharpriborn.BL.Extensions;

public static class BusinessLayerServiceExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddDataAccessLayerServices();
        services.AddScoped<ICarBL, CarBL>();

        return services;
    }

}
