# PROCOMER Technical Practice

Repositorio de práctica para la prueba técnica del perfil **Programador**.

El objetivo es preparar una solución alineada con la rúbrica de evaluación de PROCOMER, practicando análisis, presentación, microservicios, arquitectura limpia, SQL Server, Entity Framework, Dapper, pruebas y despliegue.

---

## Perfil evaluado

El perfil de Programador requiere experiencia práctica en:

- C# y .NET Core.
- Desarrollo de microservicios.
- Clean Architecture, MVC o arquitecturas similares.
- APIs RESTful.
- Manejo de JSON y XML.
- SQL Server.
- Entity Framework.
- Dapper.
- Azure.
- Azure Active Directory / Microsoft Entra ID.
- Azure Service Bus.
- Contenedores y Azure Container Apps.
- Azure DevOps.
- Power BI o DevExpress Reports.
- Pruebas funcionales, estructurales, integración, sistema o aceptación.

---

## Rúbrica resumida

| Rubro | Puntos |
|---|---:|
| Análisis del requerimiento | 10 |
| Planificación / prototipo | 10 |
| Capa de presentación: ASP MVC, JavaScript, AJAX, jQuery, Angular | 10 |
| Microservicios / Clean Architecture / REST / SQL Server / EF / Dapper | 50 |
| Buenas prácticas y unit tests | 5 |
| Eficiencia y gestión del tiempo | 10 |
| Cumplimiento general | 5 |

---

## Roadmap de ejercicios

### R0 - Análisis y casos de uso

Estado: completado.

Objetivo:

- Analizar requerimientos.
- Documentar reglas de negocio.
- Crear diagramas de proceso.
- Crear casos de uso.
- Definir prototipo inicial.

Ubicación:

```text
exercises/R0-RequirementAnalysis
```

---

### R1 - ASP.NET MVC + jQuery + AJAX

Estado: completado.

Objetivo:

- Crear una aplicación ASP.NET MVC.
- Utilizar Razor Views.
- Implementar formularios con validaciones.
- Usar ViewModels.
- Usar JavaScript, jQuery y AJAX.
- Registrar empleados sin refrescar la página.

Ubicación:

```text
exercises/R1-MvcJqueryAjax
```

---

### R1.5 - Unit tests y limpieza de R1

Estado: completado.

Objetivo:

- Agregar pruebas unitarias.
- Probar lógica de negocio.
- Probar validaciones con DataAnnotations.
- Reforzar buenas prácticas.

Ubicación:

```text
exercises/R1-MvcJqueryAjax
```

---

### R2 - ASP.NET Core Web API + Clean Architecture

Estado: completado.

Objetivo:

- Construir API REST.
- Separar capas Domain, Application, Infrastructure y Api.
- Implementar repositorio en memoria.
- Agregar pruebas de dominio, aplicación, infraestructura e integración API.

Ubicación:

```text
exercises/R2-CleanAPI
```

---

### R3 - SQL Server 2019 + Entity Framework / LINQ

Estado: pendiente.

Objetivo:

- Integrar SQL Server 2019.
- Agregar Entity Framework Core.
- Crear DbContext.
- Crear migraciones.
- Implementar repositorio EF.
- Practicar consultas LINQ.

Ubicación propuesta:

```text
exercises/R2-CleanAPI
```

Nota: R3 continuará sobre el proyecto R2 para reemplazar el repositorio en memoria por SQL Server + EF.

---

### R4 - Dapper + consultas SQL optimizadas

Estado: pendiente.

Objetivo:

- Instalar Dapper.
- Crear consultas SQL directas.
- Implementar reportes o consultas optimizadas.
- Comparar EF vs Dapper.

---

### R5 - Angular + API REST

Estado: pendiente.

Objetivo:

- Crear una UI Angular.
- Consumir API REST.
- Implementar formularios reactivos.
- Manejar validaciones y errores.
- Mostrar empleados desde la API.

---

### R6 - Microservicio completo con Docker y preparación Azure

Estado: pendiente.

Objetivo:

- Integrar Clean Architecture, SQL Server, EF, Dapper y API REST.
- Agregar Docker.
- Preparar despliegue conceptual hacia Azure Container Apps.
- Revisar Azure Service Bus y configuración cloud.

---

### R7 - Simulacro PROCOMER 6 horas

Estado: pendiente.

Objetivo:

- Resolver un ejercicio completo contra reloj.
- Generar análisis, prototipo, implementación, pruebas y defensa oral.
- Practicar entrega antes de 4 horas y antes de 6 horas.

---

## Estructura esperada del repositorio

```text
ProcomerPractice/
├── .gitignore
├── README.md
├── docs/
└── exercises/
    ├── R0-RequirementAnalysis/
    ├── R1-MvcJqueryAjax/
    └── R2-CleanAPI/
```

---

## Comandos útiles

### Compilar una solución

```powershell
dotnet build
```

### Ejecutar pruebas

```powershell
dotnet test
```

### Ejecutar una API

```powershell
dotnet run
```

### Ejecutar R1

```powershell
dotnet run --project .\exercises\R1-MvcJqueryAjax\EmployeeManagement.Web\EmployeeManagement.Web.csproj
```

### Ejecutar R2

```powershell
dotnet run --project .\exercises\R2-CleanAPI\EmployeeManagement.Api\EmployeeManagement.Api.csproj
```

### Crear migración EF

```powershell
dotnet ef migrations add InitialCreate --project <InfrastructureProject> --startup-project <ApiProject>
```

### Aplicar migración EF

```powershell
dotnet ef database update --project <InfrastructureProject> --startup-project <ApiProject>
```

---

## Validación rápida del repositorio

Desde la raíz del repositorio:

```powershell
cd C:\ProcomerPractice
```

Compilar y probar R1:

```powershell
dotnet build .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln
dotnet test .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln
```

Compilar y probar R2:

```powershell
dotnet build .\exercises\R2-CleanAPI\EmployeeManagement.sln
dotnet test .\exercises\R2-CleanAPI\EmployeeManagement.sln
```

Si tu carpeta real se llama `R2-CleanApi` en lugar de `R2-CleanAPI`, ajusta los comandos al nombre real.

---

## Estrategia para la prueba

Orden recomendado durante el examen:

1. Leer cuidadosamente el requerimiento.
2. Crear análisis y diagrama simple.
3. Crear casos de uso.
4. Definir prototipo rápido.
5. Crear solución base.
6. Implementar Domain.
7. Implementar Application.
8. Implementar Infrastructure.
9. Implementar API REST.
10. Implementar SQL Server / EF / Dapper según aplique.
11. Implementar presentación.
12. Agregar unit tests.
13. Probar manualmente.
14. Preparar explicación final.

---

## Checklist de entrega para simulacro

Antes de entregar una solución, revisar:

- [ ] La aplicación compila.
- [ ] La aplicación ejecuta sin errores técnicos.
- [ ] Los endpoints principales funcionan.
- [ ] El formulario cumple todos los campos requeridos.
- [ ] Las validaciones principales funcionan.
- [ ] Existe separación entre presentación, aplicación, dominio e infraestructura.
- [ ] Existe acceso a datos SQL Server cuando el ejercicio lo requiere.
- [ ] Se usó EF o Dapper según el requerimiento.
- [ ] Existen pruebas unitarias o de integración básicas.
- [ ] El código está ordenado y con nombres claros.
- [ ] Se puede explicar la solución en pocos minutos.

---

## Regla principal

Primero funcionalidad correcta.  
Después limpieza.  
Después optimización.

Una solución simple, funcional, con arquitectura clara y pruebas básicas puntúa mejor que una solución ambiciosa pero incompleta.
