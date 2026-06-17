# R0 - Prototipo funcional

## 1. Objetivo

Definir el diseño preliminar de la interfaz antes de iniciar el desarrollo.

Este documento cubre parcialmente el rubro:

> Planificación de la solución y estrategia de desarrollo
>
> Elaboración de prototipo y aplicación en producto finalizado.

---

# 2. Pantallas identificadas

El sistema requiere inicialmente una única pantalla:

## Gestión de Empleados

Responsabilidades:

- Registrar empleados.
- Consultar empleados.
- Visualizar bonificación anual.
- Mostrar validaciones.
- Mostrar errores de negocio.

---

# 3. Wireframe de pantalla

```text
+---------------------------------------------------+
|               GESTIÓN DE EMPLEADOS                |
+---------------------------------------------------+

Nombre Completo
[________________________________]

Correo Electrónico
[________________________________]

Departamento
[____________▼__________________]

Salario Mensual
[________________________________]

Fecha de Ingreso
[________________________________]

                [ Guardar ]

-----------------------------------------------------

EMPLEADOS REGISTRADOS

+----+----------------+-------------+--------------+
| ID | Nombre         | Departamento| Bonificación |
+----+----------------+-------------+--------------+
| 1  | Ana Morales    | TI          | ₡500,000     |
| 2  | Carlos Rojas   | Finanzas    | ₡850,000     |
+----+----------------+-------------+--------------+
```

---

# 4. Componentes de interfaz

## Employee Form

Responsabilidad:

Capturar datos del empleado.

Campos:

- Nombre completo
- Correo electrónico
- Departamento
- Salario mensual
- Fecha de ingreso

Acciones:

- Guardar

Validaciones:

- Requeridos
- Email válido
- Salario > 0
- Fecha no futura

---

## Employee List

Responsabilidad:

Mostrar empleados registrados.

Columnas:

- Id
- Nombre
- Departamento
- Salario
- Fecha ingreso
- Bonificación

---

## Notification Area

Responsabilidad:

Mostrar mensajes de:

- Error
- Advertencia
- Éxito

Ejemplos:

```text
Empleado registrado correctamente.
```

```text
Debe completar todos los campos requeridos.
```

```text
No fue posible guardar el empleado.
```

---

# 5. Arquitectura visual propuesta

```text
+-----------------------------+
|         EmployeesPage       |
+-----------------------------+
              |
    +---------+---------+
    |                   |
    ▼                   ▼

EmployeeForm      EmployeeList
```

---

# 6. Flujo de navegación

```text
Usuario
   |
   ▼
Gestión de Empleados
   |
   +--> Registrar empleado
   |
   +--> Consultar empleados
```

No se requieren pantallas adicionales para este ejercicio.

---

# 7. API requerida por la interfaz

## Obtener empleados

```http
GET /api/employees
```

Respuesta:

```json
[
  {
    "id": 1,
    "fullName": "Ana Morales",
    "department": "TI"
  }
]
```

---

## Crear empleado

```http
POST /api/employees
```

Request:

```json
{
  "fullName": "Ana Morales",
  "email": "ana@empresa.com",
  "department": "TI",
  "monthlySalary": 1000000,
  "hireDate": "2024-01-15"
}
```

Response:

```json
{
  "id": 1,
  "fullName": "Ana Morales"
}
```

---

# 8. Plan de implementación

## Fase 1

Análisis

- Requerimientos
- Casos de uso
- Diagramas

---

## Fase 2

Frontend

- Angular
- Formularios reactivos
- Validaciones

---

## Fase 3

Backend

- ASP.NET Core
- REST APIs

---

## Fase 4

Persistencia

- SQL Server
- Entity Framework
- Dapper

---

## Fase 5

Pruebas

- Unit Tests
- Integration Tests

---

# 9. Riesgos identificados

| Riesgo | Mitigación |
|----------|----------|
| Validaciones inconsistentes | Validar en frontend y backend |
| Errores de integración | Pruebas de API tempranas |
| Problemas de persistencia | Repositorios y pruebas unitarias |
| Cambios de requerimiento | Casos de uso y documentación actualizada |

---

# 10. Resultado esperado

El usuario podrá:

1. Registrar empleados.
2. Consultar empleados.
3. Visualizar bonificación anual.
4. Recibir validaciones claras.
5. Operar mediante una interfaz web simple y consistente.

Este prototipo servirá como base para los ejercicios R1, R2, R3, R4 y R5.