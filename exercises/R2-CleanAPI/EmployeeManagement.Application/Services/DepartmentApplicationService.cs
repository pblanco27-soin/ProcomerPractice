using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services;

public class DepartmentApplicationService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentApplicationService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public List<DepartmentResponse> GetAll()
    {
        return _departmentRepository
            .GetAll()
            .Select(MapToResponse)
            .ToList();
    }

    public DepartmentResponse? GetById(int id)
    {
        var department = _departmentRepository.GetById(id);

        if (department is null)
        {
            return null;
        }

        return MapToResponse(department);
    }

    private static DepartmentResponse MapToResponse(Department department)
    {
        return new DepartmentResponse
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}

