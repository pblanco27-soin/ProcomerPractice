using Microsoft.AspNetCore.Mvc;

using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.ViewModels;

namespace EmployeeManagement.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new EmployeesPageViewModel
        {
            Form = new CreateEmployeeViewModel(),
            Departments = _employeeService.GetDepartments(),
            Employees = _employeeService.GetEmployees()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create([Bind(Prefix = "Form")] CreateEmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            if (IsAjaxRequest())
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    message = "Debe corregir los errores del formulario.",
                    errors
                });
            }

            var pageModel = new EmployeesPageViewModel
            {
                Form = model,
                Departments = _employeeService.GetDepartments(),
                Employees = _employeeService.GetEmployees()
            };

            return View("Index", pageModel);
        }

        var employee = _employeeService.Create(model);

        if (IsAjaxRequest())
        {
            return Json(new
            {
                success = true,
                employee
            });
        }

        return RedirectToAction(nameof(Index));
    }

    private bool IsAjaxRequest()
    {
        return Request.Headers.XRequestedWith == "XMLHttpRequest";
    }
}