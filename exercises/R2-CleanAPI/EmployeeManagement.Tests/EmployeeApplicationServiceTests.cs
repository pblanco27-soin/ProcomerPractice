using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Tests;

public class EmployeeApplicationServiceTests
{
    [Fact]
    public void Create_WhenRequestIsValid_ReturnsCreatedEmployeeResponse()
    {
        // Arrange
        var repository = new FakeEmployeeRepository();
        var service = new EmployeeApplicationService(repository);

        var request = new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        };

        // Act
        var result = service.Create(request);

        // Assert
        Assert.Equal(1, result.Id);
        Assert.Equal("Ana Morales", result.FullName);
        Assert.Equal("ana@empresa.com", result.Email);
        Assert.Equal(1, result.DepartmentId);
        Assert.Equal(1_000_000m, result.MonthlySalary);
        Assert.Equal(500_000m, result.AnnualBonus);
    }

    [Fact]
    public void GetAll_WhenEmployeesExist_ReturnsEmployees()
    {
        // Arrange
        var repository = new FakeEmployeeRepository();
        var service = new EmployeeApplicationService(repository);

        service.Create(new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        });

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Single(result);
        Assert.Equal("Ana Morales", result[0].FullName);
    }

    [Fact]
    public void GetById_WhenEmployeeExists_ReturnsEmployee()
    {
        // Arrange
        var repository = new FakeEmployeeRepository();
        var service = new EmployeeApplicationService(repository);

        var created = service.Create(new CreateEmployeeRequest
        {
            FullName = "Carlos Rojas",
            Email = "carlos@empresa.com",
            DepartmentId = 2,
            MonthlySalary = 850_000m,
            HireDate = DateTime.Today.AddYears(-5)
        });

        // Act
        var result = service.GetById(created.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Carlos Rojas", result!.FullName);
    }

    [Fact]
    public void GetById_WhenEmployeeDoesNotExist_ReturnsNull()
    {
        // Arrange
        var repository = new FakeEmployeeRepository();
        var service = new EmployeeApplicationService(repository);

        // Act
        var result = service.GetById(999);

        // Assert
        Assert.Null(result);
    }

    private class FakeEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = [];

        public List<Employee> GetAll()
        {
            return _employees;
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
}