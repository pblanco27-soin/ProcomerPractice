namespace EmployeeManagement.Application.DTOs;

public class BonusSummaryReportResponse
{
    public int TotalEmployees { get; set; }

    public decimal TotalMonthlySalary { get; set; }

    public decimal TotalAnnualBonus { get; set; }

    public decimal AverageAnnualBonus { get; set; }
}