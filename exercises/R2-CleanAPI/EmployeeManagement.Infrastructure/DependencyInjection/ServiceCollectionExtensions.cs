using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Persistence;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EmployeeManagementDb");

        services.AddDbContext<EmployeeManagementDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
        services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();

        return services;
    }
}