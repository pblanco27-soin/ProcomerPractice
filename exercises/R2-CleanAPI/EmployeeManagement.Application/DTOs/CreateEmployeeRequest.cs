namespace EmployeeManagement.Application.DTOs;

public class CreateEmployeeRequest
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public decimal MonthlySalary { get; set; }

    public DateTime HireDate { get; set; }
}