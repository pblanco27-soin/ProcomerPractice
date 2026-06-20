using EmployeeManagement.Domain.Exceptions;

namespace EmployeeManagement.Domain.Entities;

public class Department
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public Department(int id, string name)
    {
        if (id <= 0)
        {
            throw new DomainValidationException("El identificador del departamento debe ser mayor a cero.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainValidationException("El nombre del departamento es requerido.");
        }

        Id = id;
        Name = name.Trim();
    }
}