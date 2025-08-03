using System;
using ActivitiesGo.Aplication.Interfaces;
using ActivitiesGo.Aplication.Services;
using ActivitiesGo.Domain.Interfaces;
using ActivitiesGo.InfraData.Repositories;

namespace ActivitiesGo.API.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService,AuthService>();
        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}
