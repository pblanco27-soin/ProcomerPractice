using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Repositories;

namespace EmployeeManagement.Tests;

public class InMemoryEmployeeRepositoryTests
{
    [Fact]
    public void Create_WhenEmployeeIsValid_StoresEmployee()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();

        var employee = new Employee(
            id: 1,
            fullName: "Ana Morales",
            email: "ana@empresa.com",
            departmentId: 1,
            monthlySalary: 1_000_000m,
            hireDate: DateTime.Today.AddYears(-2)
        );

        // Act
        repository.Create(employee);
        var employees = repository.GetAll();

        // Assert
        Assert.Single(employees);
        Assert.Equal("Ana Morales", employees[0].FullName);
    }

    [Fact]
    public void GetById_WhenEmployeeExists_ReturnsEmployee()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();

        var employee = new Employee(
            id: 1,
            fullName: "Carlos Rojas",
            email: "carlos@empresa.com",
            departmentId: 2,
            monthlySalary: 850_000m,
            hireDate: DateTime.Today.AddYears(-5)
        );

        repository.Create(employee);

        // Act
        var result = repository.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Carlos Rojas", result!.FullName);
    }

    [Fact]
    public void GetNextId_WhenNoEmployeesExist_ReturnsOne()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();

        // Act
        var result = repository.GetNextId();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetNextId_WhenEmployeesExist_ReturnsNextAvailableId()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();

        repository.Create(new Employee(
            id: 1,
            fullName: "Ana Morales",
            email: "ana@empresa.com",
            departmentId: 1,
            monthlySalary: 1_000_000m,
            hireDate: DateTime.Today.AddYears(-2)
        ));

        // Act
        var result = repository.GetNextId();

        // Assert
        Assert.Equal(2, result);
    }
}