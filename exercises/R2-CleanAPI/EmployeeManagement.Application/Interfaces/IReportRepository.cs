using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces;

public interface IReportRepository
{
    List<EmployeesByDepartmentReportResponse> GetEmployeesByDepartment();

    BonusSummaryReportResponse GetBonusSummary();
}