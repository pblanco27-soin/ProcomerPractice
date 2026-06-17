# R0 - Análisis del requerimiento

## 1. Objetivo del sistema

Desarrollar una aplicación para gestionar empleados y departamentos de una organización.

El sistema debe permitir registrar empleados, consultar empleados existentes y calcular una bonificación anual según la antigüedad del empleado.

Este ejercicio se utilizará como base para practicar análisis de requerimientos, diseño de casos de uso, prototipo de interfaz, desarrollo de API REST, acceso a datos, pruebas unitarias y arquitectura limpia.

---

## 2. Alcance funcional

El sistema debe permitir:

1. Registrar empleados.
2. Consultar empleados registrados.
3. Asociar cada empleado a un departamento.
4. Calcular la bonificación anual de cada empleado.
5. Validar los datos ingresados antes de guardar.

---

## 3. Entidades principales

### Employee

Representa a una persona colaboradora de la organización.

Campos:

| Campo | Tipo | Requerido | Reglas |
|---|---|---:|---|
| Id | Entero | Sí | Identificador único |
| FullName | Texto | Sí | Mínimo 3 caracteres |
| Email | Texto | Sí | Formato de correo válido |
| DepartmentId | Entero | Sí | Debe existir un departamento asociado |
| MonthlySalary | Decimal | Sí | Debe ser mayor a cero |
| HireDate | Fecha | Sí | No puede ser futura |

### Department

Representa un departamento de la organización.

Campos:

| Campo | Tipo | Requerido | Reglas |
|---|---|---:|---|
| Id | Entero | Sí | Identificador único |
| Name | Texto | Sí | No debe estar vacío |

---

## 4. Reglas de negocio

### BR-01: Validación de nombre

El nombre completo del empleado es obligatorio y debe tener al menos 3 caracteres.

### BR-02: Validación de correo

El correo electrónico es obligatorio y debe tener un formato válido.

### BR-03: Validación de departamento

Todo empleado debe estar asociado a un departamento existente.

### BR-04: Validación de salario

El salario mensual debe ser mayor a cero.

### BR-05: Validación de fecha de ingreso

La fecha de ingreso es obligatoria y no puede ser futura.

### BR-06: Cálculo de bonificación anual

La bonificación anual se calcula según la antigüedad del empleado:

| Antigüedad | Bonificación |
|---|---:|
| Menos de 1 año | 0% del salario mensual |
| Entre 1 y 3 años | 50% del salario mensual |
| Más de 3 años | 100% del salario mensual |

---

## 5. Entradas del sistema

El usuario debe ingresar:

1. Nombre completo.
2. Correo electrónico.
3. Departamento.
4. Salario mensual.
5. Fecha de ingreso.

---

## 6. Salidas del sistema

El sistema debe mostrar:

1. Lista de empleados registrados.
2. Departamento asociado a cada empleado.
3. Salario mensual.
4. Fecha de ingreso.
5. Bonificación anual calculada.
6. Mensajes de validación o error.

---

## 7. Supuestos

1. Los departamentos estarán previamente registrados.
2. El usuario tendrá permisos para registrar y consultar empleados.
3. La aplicación será utilizada desde una interfaz web.
4. La información será persistida posteriormente en SQL Server.
5. El cálculo de bonificación será realizado por la capa de dominio o aplicación, no por la interfaz.

---

## 8. Criterios de aceptación

### CA-01: Registro exitoso

Dado que el usuario ingresa datos válidos,
cuando presiona el botón Guardar,
entonces el sistema registra el empleado y lo muestra en la lista.

### CA-02: Validación de campos requeridos

Dado que el usuario deja campos obligatorios vacíos,
cuando intenta guardar,
entonces el sistema muestra mensajes de validación y no guarda el empleado.

### CA-03: Validación de salario

Dado que el usuario ingresa un salario menor o igual a cero,
cuando intenta guardar,
entonces el sistema muestra un mensaje indicando que el salario debe ser mayor a cero.

### CA-04: Validación de fecha futura

Dado que el usuario ingresa una fecha de ingreso futura,
cuando intenta guardar,
entonces el sistema muestra un mensaje indicando que la fecha de ingreso no puede ser futura.

### CA-05: Cálculo de bonificación

Dado que existe un empleado registrado,
cuando se consulta la lista de empleados,
entonces el sistema muestra la bonificación anual calculada según su antigüedad.