namespace EmployeeManagement.Web.ViewModels;

public class EmployeeListItemViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string DepartmentName { get; set; } = string.Empty;

    public decimal MonthlySalary { get; set; }

    public DateTime HireDate { get; set; }

    public decimal AnnualBonus { get; set; }
}