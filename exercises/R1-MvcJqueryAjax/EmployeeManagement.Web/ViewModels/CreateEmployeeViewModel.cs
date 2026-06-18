using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.ViewModels;

public class CreateEmployeeViewModel
{
    [Required(ErrorMessage = "El nombre completo es requerido.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es requerido.")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El departamento es requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un departamento.")]
    [Display(Name = "Departamento")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "El salario mensual es requerido.")]
    [Range(1, double.MaxValue, ErrorMessage = "El salario mensual debe ser mayor a cero.")]
    [Display(Name = "Salario mensual")]
    public decimal MonthlySalary { get; set; }

    [Required(ErrorMessage = "La fecha de ingreso es requerida.")]
    [Display(Name = "Fecha de ingreso")]
    public DateTime HireDate { get; set; } = DateTime.Today;
}