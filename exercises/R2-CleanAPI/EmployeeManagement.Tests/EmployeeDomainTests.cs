using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Exceptions;

namespace EmployeeManagement.Tests;

public class EmployeeDomainTests
{
    [Fact]
    public void Constructor_WhenDataIsValid_CreatesEmployee()
    {
        var employee = new Employee(
            id: 1,
            fullName: "Ana Morales",
            email: "ana@empresa.com",
            departmentId: 1,
            monthlySalary: 1_000_000m,
            hireDate: DateTime.Today.AddYears(-2)
        );

        Assert.Equal(1, employee.Id);
        Assert.Equal("Ana Morales", employee.FullName);
        Assert.Equal("ana@empresa.com", employee.Email);
        Assert.Equal(1, employee.DepartmentId);
        Assert.Equal(1_000_000m, employee.MonthlySalary);
        Assert.Equal(500_000m, employee.AnnualBonus);
    }

    [Fact]
    public void Constructor_WhenFullNameIsEmpty_ThrowsDomainValidationException()
    {
        var exception = Assert.Throws<DomainValidationException>(() =>
            new Employee(
                id: 1,
                fullName: "",
                email: "ana@empresa.com",
                departmentId: 1,
                monthlySalary: 1_000_000m,
                hireDate: DateTime.Today
            )
        );

        Assert.Equal("El nombre completo es requerido.", exception.Message);
    }

    [Fact]
    public void Constructor_WhenEmailIsInvalid_ThrowsDomainValidationException()
    {
        var exception = Assert.Throws<DomainValidationException>(() =>
            new Employee(
                id: 1,
                fullName: "Ana Morales",
                email: "correo-invalido",
                departmentId: 1,
                monthlySalary: 1_000_000m,
                hireDate: DateTime.Today
            )
        );

        Assert.Equal("El correo electrónico no tiene un formato válido.", exception.Message);
    }

    [Fact]
    public void Constructor_WhenMonthlySalaryIsZero_ThrowsDomainValidationException()
    {
        var exception = Assert.Throws<DomainValidationException>(() =>
            new Employee(
                id: 1,
                fullName: "Ana Morales",
                email: "ana@empresa.com",
                departmentId: 1,
                monthlySalary: 0,
                hireDate: DateTime.Today
            )
        );

        Assert.Equal("El salario mensual debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public void Constructor_WhenHireDateIsFuture_ThrowsDomainValidationException()
    {
        var exception = Assert.Throws<DomainValidationException>(() =>
            new Employee(
                id: 1,
                fullName: "Ana Morales",
                email: "ana@empresa.com",
                departmentId: 1,
                monthlySalary: 1_000_000m,
                hireDate: DateTime.Today.AddDays(1)
            )
        );

        Assert.Equal("La fecha de ingreso no puede ser futura.", exception.Message);
    }

    [Theory]
    [InlineData(6, 1_000_000, 0)]
    [InlineData(24, 1_000_000, 500_000)]
    [InlineData(60, 1_000_000, 1_000_000)]
    public void Constructor_CalculatesAnnualBonusCorrectly(
        int monthsAgo,
        decimal monthlySalary,
        decimal expectedBonus)
    {
        var employee = new Employee(
            id: 1,
            fullName: "Ana Morales",
            email: "ana@empresa.com",
            departmentId: 1,
            monthlySalary: monthlySalary,
            hireDate: DateTime.Today.AddMonths(-monthsAgo)
        );

        Assert.Equal(expectedBonus, employee.AnnualBonus);
    }
}