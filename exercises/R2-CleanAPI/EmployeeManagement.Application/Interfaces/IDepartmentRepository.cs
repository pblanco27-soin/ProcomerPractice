using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces;

public interface IDepartmentRepository
{
    List<Department> GetAll();

    Department? GetById(int id);
}