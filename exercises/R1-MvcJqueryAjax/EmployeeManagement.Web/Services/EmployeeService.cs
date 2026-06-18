using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.ViewModels;

namespace EmployeeManagement.Web.Services;

public class EmployeeService
{
    private readonly List<Department> _departments =
    [
        new Department { Id = 1, Name = "TI" },
        new Department { Id = 2, Name = "Finanzas" },
        new Department { Id = 3, Name = "Operaciones" }
    ];

    private readonly List<Employee> _employees = [];
    private int _nextId = 1;

    public List<Department> GetDepartments()
    {
        return _departments;
    }

    public List<EmployeeListItemViewModel> GetEmployees()
    {
        return _employees
            .Select(employee => new EmployeeListItemViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                DepartmentName = employee.DepartmentName,
                MonthlySalary = employee.MonthlySalary,
                HireDate = employee.HireDate,
                AnnualBonus = employee.AnnualBonus
            })
            .ToList();
    }

    public EmployeeListItemViewModel Create(CreateEmployeeViewModel model)
    {
        var department = _departments.FirstOrDefault(x => x.Id == model.DepartmentId);

        if (department is null)
        {
            throw new InvalidOperationException("El departamento indicado no existe.");
        }

        var employee = new Employee
        {
            Id = _nextId,
            FullName = model.FullName.Trim(),
            Email = model.Email.Trim(),
            DepartmentId = model.DepartmentId,
            DepartmentName = department.Name,
            MonthlySalary = model.MonthlySalary,
            HireDate = model.HireDate,
            AnnualBonus = CalculateAnnualBonus(model.MonthlySalary, model.HireDate)
        };

        _nextId++;
        _employees.Add(employee);

        return new EmployeeListItemViewModel
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            DepartmentName = employee.DepartmentName,
            MonthlySalary = employee.MonthlySalary,
            HireDate = employee.HireDate,
            AnnualBonus = employee.AnnualBonus
        };
    }

    public decimal CalculateAnnualBonus(decimal monthlySalary, DateTime hireDate)
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