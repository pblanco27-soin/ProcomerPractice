using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using EmployeeManagement.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class EfEmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeManagementDbContext _dbContext;

    public EfEmployeeRepository(EmployeeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Employees
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new Employee(
                x.Id,
                x.FullName,
                x.Email,
                x.DepartmentId,
                x.MonthlySalary,
                x.HireDate
            ))
            .ToList();
    }

    public Employee? GetById(int id)
    {
        var record = _dbContext.Employees
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (record is null)
        {
            return null;
        }

        return new Employee(
            record.Id,
            record.FullName,
            record.Email,
            record.DepartmentId,
            record.MonthlySalary,
            record.HireDate
        );
    }

    public Employee Create(Employee employee)
    {
        var record = new EmployeeRecord
        {
            FullName = employee.FullName,
            Email = employee.Email,
            DepartmentId = employee.DepartmentId,
            MonthlySalary = employee.MonthlySalary,
            HireDate = employee.HireDate,
            AnnualBonus = employee.AnnualBonus
        };

        _dbContext.Employees.Add(record);
        _dbContext.SaveChanges();

        return new Employee(
            record.Id,
            record.FullName,
            record.Email,
            record.DepartmentId,
            record.MonthlySalary,
            record.HireDate
        );
    }

    public int GetNextId()
    {
        // SQL Server genera Id automáticamente con Identity.
        // Este método se mantiene porque Application todavía lo solicita.
        if (!_dbContext.Employees.Any())
        {
            return 1;
        }

        return _dbContext.Employees.Max(x => x.Id) + 1;
    }
}