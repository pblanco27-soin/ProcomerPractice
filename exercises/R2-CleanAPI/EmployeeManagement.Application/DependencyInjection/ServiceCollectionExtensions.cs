using EmployeeManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<EmployeeApplicationService>();
        services.AddScoped<DepartmentApplicationService>();
        services.AddScoped<ReportApplicationService>();

        return services;
    }
}