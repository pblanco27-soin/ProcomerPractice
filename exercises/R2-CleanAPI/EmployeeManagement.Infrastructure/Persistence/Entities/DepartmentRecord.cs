namespace EmployeeManagement.Infrastructure.Persistence.Entities;

public class DepartmentRecord
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<EmployeeRecord> Employees { get; set; } = [];
}