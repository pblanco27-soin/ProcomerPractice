using EmployeeManagement.Domain.Exceptions;

namespace EmployeeManagement.Domain.Entities;

public class Employee
{
    public int Id { get; private set; }

    public string FullName { get; private set; }

    public string Email { get; private set; }

    public int DepartmentId { get; private set; }

    public decimal MonthlySalary { get; private set; }

    public DateTime HireDate { get; private set; }

    public decimal AnnualBonus { get; private set; }

    public Employee(
        int id,
        string fullName,
        string email,
        int departmentId,
        decimal monthlySalary,
        DateTime hireDate)
    {
        Validate(fullName, email, departmentId, monthlySalary, hireDate);

        Id = id;
        FullName = fullName.Trim();
        Email = email.Trim();
        DepartmentId = departmentId;
        MonthlySalary = monthlySalary;
        HireDate = hireDate.Date;
        AnnualBonus = CalculateAnnualBonus(monthlySalary, hireDate);
    }

    private static void Validate(
        string fullName,
        string email,
        int departmentId,
        decimal monthlySalary,
        DateTime hireDate)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new DomainValidationException("El nombre completo es requerido.");
        }

        if (fullName.Trim().Length < 3)
        {
            throw new DomainValidationException("El nombre debe tener al menos 3 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainValidationException("El correo electrónico es requerido.");
        }

        if (!email.Contains('@'))
        {
            throw new DomainValidationException("El correo electrónico no tiene un formato válido.");
        }

        if (departmentId <= 0)
        {
            throw new DomainValidationException("El departamento es requerido.");
        }

        if (monthlySalary <= 0)
        {
            throw new DomainValidationException("El salario mensual debe ser mayor a cero.");
        }

        if (hireDate.Date > DateTime.Today)
        {
            throw new DomainValidationException("La fecha de ingreso no puede ser futura.");
        }
    }

    private static decimal CalculateAnnualBonus(decimal monthlySalary, DateTime hireDate)
    {
        var today = DateTime.Today;

        var years = today.Year - hireDate.Year;

        if (hireDate.Date > today.AddYears(-years))
        {
            years--;
        }

        if (years < 1)
        {
            return 0;
        }

        if (years <= 3)
        {
            return monthlySalary * 0.5m;
        }

        return monthlySalary;
    }
}