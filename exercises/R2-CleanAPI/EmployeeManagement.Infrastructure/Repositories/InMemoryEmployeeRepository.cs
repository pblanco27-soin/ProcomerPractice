using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Infrastructure.Repositories;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = [];

    public List<Employee> GetAll()
    {
        return _employees
            .OrderBy(x => x.Id)
            .ToList();
    }

    public Employee? GetById(int id)
    {
        return _employees.FirstOrDefault(x => x.Id == id);
    }

    public Employee Create(Employee employee)
    {
        _employees.Add(employee);
        return employee;
    }

    public int GetNextId()
    {
        if (_employees.Count == 0)
        {
            return 1;
        }

        return _employees.Max(x => x.Id) + 1;
    }
}