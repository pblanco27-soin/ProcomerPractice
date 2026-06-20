using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class EfDepartmentRepository : IDepartmentRepository
{
    private readonly EmployeeManagementDbContext _dbContext;

    public EfDepartmentRepository(EmployeeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Department> GetAll()
    {
        return _dbContext.Departments
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new Department(
                x.Id,
                x.Name
            ))
            .ToList();
    }

    public Department? GetById(int id)
    {
        var record = _dbContext.Departments
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (record is null)
        {
            return null;
        }

        return new Department(
            record.Id,
            record.Name
        );
    }
}