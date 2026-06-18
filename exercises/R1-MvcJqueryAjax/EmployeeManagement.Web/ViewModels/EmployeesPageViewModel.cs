using EmployeeManagement.Web.Models;

namespace EmployeeManagement.Web.ViewModels;

public class EmployeesPageViewModel
{
    public CreateEmployeeViewModel Form { get; set; } = new();

    public List<EmployeeListItemViewModel> Employees { get; set; } = [];

    public List<Department> Departments { get; set; } = [];
}