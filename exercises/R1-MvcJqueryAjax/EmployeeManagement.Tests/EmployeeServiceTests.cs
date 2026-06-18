using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.ViewModels;

namespace EmployeeManagement.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void CalculateAnnualBonus_WhenEmployeeHasLessThanOneYear_ReturnsZero()
    {
        // Arrange
        var service = new EmployeeService();
        var monthlySalary = 1_000_000m;
        var hireDate = DateTime.Today.AddMonths(-6);

        // Act
        var result = service.CalculateAnnualBonus(monthlySalary, hireDate);

        // Assert
        Assert.Equal(0m, result);
    }

    [Fact]
    public void CalculateAnnualBonus_WhenEmployeeHasBetweenOneAndThreeYears_ReturnsHalfMonthlySalary()
    {
        // Arrange
        var service = new EmployeeService();
        var monthlySalary = 1_000_000m;
        var hireDate = DateTime.Today.AddYears(-2);

        // Act
        var result = service.CalculateAnnualBonus(monthlySalary, hireDate);

        // Assert
        Assert.Equal(500_000m, result);
    }

    [Fact]
    public void CalculateAnnualBonus_WhenEmployeeHasMoreThanThreeYears_ReturnsMonthlySalary()
    {
        // Arrange
        var service = new EmployeeService();
        var monthlySalary = 1_000_000m;
        var hireDate = DateTime.Today.AddYears(-5);

        // Act
        var result = service.CalculateAnnualBonus(monthlySalary, hireDate);

        // Assert
        Assert.Equal(1_000_000m, result);
    }

    [Fact]
    public void Create_WhenModelIsValid_CreatesEmployeeWithDepartmentAndBonus()
    {
        // Arrange
        var service = new EmployeeService();

        var model = new CreateEmployeeViewModel
        {
            FullName = " Ana Morales ",
            Email = " ana@empresa.com ",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        };

        // Act
        var result = service.Create(model);

        // Assert
        Assert.Equal(1, result.Id);
        Assert.Equal("Ana Morales", result.FullName);
        Assert.Equal("ana@empresa.com", result.Email);
        Assert.Equal("TI", result.DepartmentName);
        Assert.Equal(1_000_000m, result.MonthlySalary);
        Assert.Equal(500_000m, result.AnnualBonus);
    }

    [Fact]
    public void GetEmployees_WhenEmployeeWasCreated_ReturnsCreatedEmployee()
    {
        // Arrange
        var service = new EmployeeService();

        var model = new CreateEmployeeViewModel
        {
            FullName = "Carlos Rojas",
            Email = "carlos@empresa.com",
            DepartmentId = 2,
            MonthlySalary = 850_000m,
            HireDate = DateTime.Today.AddYears(-5)
        };

        // Act
        service.Create(model);
        var employees = service.GetEmployees();

        // Assert
        Assert.Single(employees);
        Assert.Equal("Carlos Rojas", employees[0].FullName);
        Assert.Equal("Finanzas", employees[0].DepartmentName);
        Assert.Equal(850_000m, employees[0].AnnualBonus);
    }

    [Fact]
    public void Create_WhenDepartmentDoesNotExist_ThrowsInvalidOperationException()
    {
        // Arrange
        var service = new EmployeeService();

        var model = new CreateEmployeeViewModel
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 999,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today
        };

        // Act
        var exception = Assert.Throws<InvalidOperationException>(() => service.Create(model));

        // Assert
        Assert.Equal("El departamento indicado no existe.", exception.Message);
    }
}