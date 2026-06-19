using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces;

public interface IEmployeeRepository
{
    List<Employee> GetAll();

    Employee? GetById(int id);

    Employee Create(Employee employee);

    int GetNextId();
}