using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ReportApplicationService _reportApplicationService;

    public ReportsController(ReportApplicationService reportApplicationService)
    {
        _reportApplicationService = reportApplicationService;
    }

    [HttpGet("employees-by-department")]
    public IActionResult GetEmployeesByDepartment()
    {
        var report = _reportApplicationService.GetEmployeesByDepartment();

        return Ok(report);
    }

    [HttpGet("bonus-summary")]
    public IActionResult GetBonusSummary()
    {
        var report = _reportApplicationService.GetBonusSummary();

        return Ok(report);
    }
}