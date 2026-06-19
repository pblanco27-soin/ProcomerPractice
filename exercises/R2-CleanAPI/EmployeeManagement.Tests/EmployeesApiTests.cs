using System.Net;
using System.Net.Http.Json;
using EmployeeManagement.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EmployeeManagement.Tests;

public class EmployeesApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public EmployeesApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_WhenNoEmployeesExist_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/Employees");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var employees = await response.Content.ReadFromJsonAsync<List<EmployeeResponse>>();

        Assert.NotNull(employees);
    }

    [Fact]
    public async Task Create_WhenRequestIsValid_ReturnsCreated()
    {
        var request = new CreateEmployeeRequest
        {
            FullName = "Ana Morales",
            Email = "ana@empresa.com",
            DepartmentId = 1,
            MonthlySalary = 1_000_000m,
            HireDate = DateTime.Today.AddYears(-2)
        };

        var response = await _client.PostAsJsonAsync("/api/Employees", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var employee = await response.Content.ReadFromJsonAsync<EmployeeResponse>();

        Assert.NotNull(employee);
        Assert.Equal("Ana Morales", employee!.FullName);
        Assert.Equal(500_000m, employee.AnnualBonus);
    }

    [Fact]
    public async Task Create_WhenRequestIsInvalid_ReturnsBadRequest()
    {
        var request = new CreateEmployeeRequest
        {
            FullName = "",
            Email = "correo-invalido",
            DepartmentId = 0,
            MonthlySalary = 0,
            HireDate = DateTime.Today
        };

        var response = await _client.PostAsJsonAsync("/api/Employees", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetById_WhenEmployeeDoesNotExist_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/Employees/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}