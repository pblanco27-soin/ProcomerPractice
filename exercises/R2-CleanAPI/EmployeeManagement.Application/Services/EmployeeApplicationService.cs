using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services;

public class EmployeeApplicationService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeApplicationService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<EmployeeResponse> GetAll()
    {
        return _employeeRepository
            .GetAll()
            .Select(MapToResponse)
            .ToList();
    }

    public EmployeeResponse? GetById(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee is null)
        {
            return null;
        }

        return MapToResponse(employee);
    }

    public EmployeeResponse Create(CreateEmployeeRequest request)
    {
        var nextId = _employeeRepository.GetNextId();

        var employee = new Employee(
            id: nextId,
            fullName: request.FullName,
            email: request.Email,
            departmentId: request.DepartmentId,
            monthlySalary: request.MonthlySalary,
            hireDate: request.HireDate
        );

        var createdEmployee = _employeeRepository.Create(employee);

        return MapToResponse(createdEmployee);
    }

    private static EmployeeResponse MapToResponse(Employee employee)
    {
        return new EmployeeResponse
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            DepartmentId = employee.DepartmentId,
            MonthlySalary = employee.MonthlySalary,
            HireDate = employee.HireDate,
            AnnualBonus = employee.AnnualBonus
        };
    }
}