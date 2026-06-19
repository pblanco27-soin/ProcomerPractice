using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeApplicationService _employeeApplicationService;

    public EmployeesController(EmployeeApplicationService employeeApplicationService)
    {
        _employeeApplicationService = employeeApplicationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _employeeApplicationService.GetAll();

        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var employee = _employeeApplicationService.GetById(id);

        if (employee is null)
        {
            return NotFound(new
            {
                message = "El empleado no existe."
            });
        }

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployeeRequest request)
    {
        try
        {
            var employee = _employeeApplicationService.Create(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = employee.Id },
                employee
            );
        }
        catch (DomainValidationException exception)
        {
            return BadRequest(new
            {
                message = exception.Message
            });
        }
    }
}