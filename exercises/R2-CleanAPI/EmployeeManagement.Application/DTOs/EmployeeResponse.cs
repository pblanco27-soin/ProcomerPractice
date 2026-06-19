namespace EmployeeManagement.Application.DTOs;

public class EmployeeResponse
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public decimal MonthlySalary { get; set; }

    public DateTime HireDate { get; set; }

    public decimal AnnualBonus { get; set; }
}