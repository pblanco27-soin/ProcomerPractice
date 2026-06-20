using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Exceptions;

namespace EmployeeManagement.Tests;

public class EmployeeApplicationServiceTests
{
    [Fact]
    public void Create_WhenRequestIsValid_ReturnsCreatedEmployeeResponse()
    {
        var employeeRepository = new FakeEmployeeRepository();
        var departmentRepository = new FakeDepartmentRepository();
        var service = new EmployeeApplicationService(employeeRepository, departmentRepository);

        var request = new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        };

        var result = service.Create(request);

        Assert.Equal(1, result.Id);
        Assert.Equal("Ana Morales", result.FullName);
        Assert.Equal("ana@empresa.com", result.Email);
        Assert.Equal(1, result.DepartmentId);
        Assert.Equal(1_000_000m, result.MonthlySalary);
        Assert.Equal(500_000m, result.AnnualBonus);
    }

    [Fact]
    public void Create_WhenDepartmentDoesNotExist_ThrowsDomainValidationException()
    {
        var employeeRepository = new FakeEmployeeRepository();
        var departmentRepository = new FakeDepartmentRepository();
        var service = new EmployeeApplicationService(employeeRepository, departmentRepository);

        var request = new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 999,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        };

        var exception = Assert.Throws<DomainValidationException>(() => service.Create(request));

        Assert.Equal("El departamento indicado no existe.", exception.Message);
    }

    [Fact]
    public void GetAll_WhenEmployeesExist_ReturnsEmployees()
    {
        var employeeRepository = new FakeEmployeeRepository();
        var departmentRepository = new FakeDepartmentRepository();
        var service = new EmployeeApplicationService(employeeRepository, departmentRepository);

        service.Create(new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        });

        var result = service.GetAll();

        Assert.Single(result);
        Assert.Equal("Ana Morales", result[0].FullName);
    }

    [Fact]
    public void GetById_WhenEmployeeExists_ReturnsEmployee()
    {
        var employeeRepository = new FakeEmployeeRepository();
        var departmentRepository = new FakeDepartmentRepository();
        var service = new EmployeeApplicationService(employeeRepository, departmentRepository);

        var created = service.Create(new CreateEmployeeRequest
        {
            FullName = "Carlos Rojas",
            Email = "carlos@empresa.com",
            DepartmentId = 2,
            MonthlySalary = 850_000m,
            HireDate = DateTime.Today.AddYears(-5)
        });

        var result = service.GetById(created.Id);

        Assert.NotNull(result);
        Assert.Equal("Carlos Rojas", result!.FullName);
    }

    [Fact]
    public void GetById_WhenEmployeeDoesNotExist_ReturnsNull()
    {
        var employeeRepository = new FakeEmployeeRepository();
        var departmentRepository = new FakeDepartmentRepository();
        var service = new EmployeeApplicationService(employeeRepository, departmentRepository);

        var result = service.GetById(999);

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

    private class FakeDepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments =
        [
            new Department(1, "TI"),
            new Department(2, "Finanzas"),
            new Department(3, "Operaciones")
        ];

        public List<Department> GetAll()
        {
            return _departments;
        }

        public Department? GetById(int id)
        {
            return _departments.FirstOrDefault(x => x.Id == id);
        }
    }
}