using Dapper;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Infrastructure.Repositories;

public class DapperReportRepository : IReportRepository
{
    private readonly string _connectionString;

    public DapperReportRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("EmployeeManagementDb")
            ?? throw new InvalidOperationException("Connection string EmployeeManagementDb was not found.");
    }

    public List<EmployeesByDepartmentReportResponse> GetEmployeesByDepartment()
    {
        const string sql = """
            SELECT
                d.Id AS DepartmentId,
                d.Name AS DepartmentName,
                COUNT(e.Id) AS EmployeeCount,
                COALESCE(SUM(e.MonthlySalary), 0) AS TotalMonthlySalary,
                COALESCE(SUM(e.AnnualBonus), 0) AS TotalAnnualBonus
            FROM Departments d
            LEFT JOIN Employees e ON e.DepartmentId = d.Id
            GROUP BY d.Id, d.Name
            ORDER BY d.Name;
            """;

        using var connection = new SqlConnection(_connectionString);

        return connection
            .Query<EmployeesByDepartmentReportResponse>(sql)
            .ToList();
    }

    public BonusSummaryReportResponse GetBonusSummary()
    {
        const string sql = """
            SELECT
                COUNT(e.Id) AS TotalEmployees,
                COALESCE(SUM(e.MonthlySalary), 0) AS TotalMonthlySalary,
                COALESCE(SUM(e.AnnualBonus), 0) AS TotalAnnualBonus,
                COALESCE(AVG(e.AnnualBonus), 0) AS AverageAnnualBonus
            FROM Employees e;
            """;

        using var connection = new SqlConnection(_connectionString);

        return connection.QuerySingle<BonusSummaryReportResponse>(sql);
    }
}