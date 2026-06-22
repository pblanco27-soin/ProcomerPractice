using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.Services;

public class ReportApplicationService
{
    private readonly IReportRepository _reportRepository;

    public ReportApplicationService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public List<EmployeesByDepartmentReportResponse> GetEmployeesByDepartment()
    {
        return _reportRepository.GetEmployeesByDepartment();
    }

    public BonusSummaryReportResponse GetBonusSummary()
    {
        return _reportRepository.GetBonusSummary();
    }
}