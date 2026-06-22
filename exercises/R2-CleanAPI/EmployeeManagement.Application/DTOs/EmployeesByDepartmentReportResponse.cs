namespace EmployeeManagement.Application.DTOs;

public class EmployeesByDepartmentReportResponse
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public int EmployeeCount { get; set; }

    public decimal TotalMonthlySalary { get; set; }

    public decimal TotalAnnualBonus { get; set; }
}