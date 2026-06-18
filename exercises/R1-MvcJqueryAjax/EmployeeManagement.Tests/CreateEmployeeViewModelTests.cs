using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Web.ViewModels;

namespace EmployeeManagement.Tests;

public class CreateEmployeeViewModelTests
{
    [Fact]
    public void Validate_WhenModelIsValid_ReturnsNoErrors()
    {
        // Arrange
        var model = new CreateEmployeeViewModel
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void Validate_WhenRequiredFieldsAreEmpty_ReturnsValidationErrors()
    {
        // Arrange
        var model = new CreateEmployeeViewModel
        {
            FullName = "",
            Email = "",
            DepartmentId = 0,
            MonthlySalary = 0,
            HireDate = DateTime.Today
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateEmployeeViewModel.FullName)));
        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateEmployeeViewModel.Email)));
        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateEmployeeViewModel.DepartmentId)));
        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateEmployeeViewModel.MonthlySalary)));
    }

    [Fact]
    public void Validate_WhenEmailIsInvalid_ReturnsEmailValidationError()
    {
        // Arrange
        var model = new CreateEmployeeViewModel
        {
            FullName = "Ana Morales",
            Email = "correo-invalido",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today
        };

        // Act
        var results = ValidateModel(model);

        // Assert
        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateEmployeeViewModel.Email)));
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();

        var context = new ValidationContext(model);

        Validator.TryValidateObject(
            model,
            context,
            validationResults,
            validateAllProperties: true
        );

        return validationResults;
    }
}