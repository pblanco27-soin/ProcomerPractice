using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly DepartmentApplicationService _departmentApplicationService;

    public DepartmentsController(DepartmentApplicationService departmentApplicationService)
    {
        _departmentApplicationService = departmentApplicationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var departments = _departmentApplicationService.GetAll();

        return Ok(departments);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var department = _departmentApplicationService.GetById(id);

        if (department is null)
        {
            return NotFound(new
            {
                message = "El departamento no existe."
            });
        }

        return Ok(department);
    }
}