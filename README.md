# PROCOMER Technical Practice

Repositorio de práctica para la prueba técnica del perfil **Programador**.

El objetivo es preparar una solución alineada con la rúbrica de evaluación de PROCOMER, practicando análisis, presentación, microservicios, arquitectura limpia, SQL Server, Entity Framework, Dapper, pruebas, Docker y preparación conceptual para Azure.

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

## Estado actual

| Ejercicio | Estado | Enfoque |
|---|---|---|
| R0 | Completado | Análisis, diagramas y casos de uso |
| R1 | Completado | ASP.NET MVC, Razor, jQuery y AJAX |
| R1.5 | Completado | Unit tests y limpieza |
| R2 | Completado | Web API + Clean Architecture |
| R3 | Completado | SQL Server 2019 + Entity Framework Core |
| R4 | Pendiente | Dapper + reportes SQL optimizados |
| R5 | Pendiente / reducido | Angular + API REST |
| R6 | Pendiente / prioritario | Docker + preparación Azure |
| R7 | Pendiente | Simulacro técnico |

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

Capas implementadas:

```text
EmployeeManagement.Domain
EmployeeManagement.Application
EmployeeManagement.Infrastructure
EmployeeManagement.Api
EmployeeManagement.Tests
```

Endpoints principales:

```http
GET  /api/Employees
GET  /api/Employees/{id}
POST /api/Employees
```

---

### R3 - SQL Server 2019 + Entity Framework Core

Estado: completado.

Objetivo:

- Integrar SQL Server 2019.
- Agregar Entity Framework Core.
- Crear DbContext.
- Crear migraciones.
- Implementar repositorio EF.
- Persistir empleados en SQL Server.
- Validar existencia de departamentos desde base de datos.
- Crear endpoint de departamentos.

Ubicación:

```text
exercises/R2-CleanAPI
```

Nota: R3 continúa sobre el proyecto R2 para evolucionar la infraestructura desde memoria hacia SQL Server + EF Core.

Componentes agregados:

```text
EmployeeManagement.Infrastructure/Persistence
EmployeeManagement.Infrastructure/Persistence/Entities
EmployeeManagement.Infrastructure/Persistence/Configurations
EmployeeManagement.Infrastructure/Persistence/Migrations
EfEmployeeRepository
EfDepartmentRepository
EmployeeManagementDbContext
```

Endpoints agregados:

```http
GET /api/Departments
GET /api/Departments/{id}
```

Comandos EF usados:

```powershell
dotnet ef migrations add InitialCreate --project .\EmployeeManagement.Infrastructure\EmployeeManagement.Infrastructure.csproj --startup-project .\EmployeeManagement.Api\EmployeeManagement.Api.csproj --output-dir Persistence\Migrations

dotnet ef database update --project .\EmployeeManagement.Infrastructure\EmployeeManagement.Infrastructure.csproj --startup-project .\EmployeeManagement.Api\EmployeeManagement.Api.csproj
```

---

### R4 - Dapper + consultas SQL optimizadas

Estado: pendiente.

Objetivo:

- Instalar Dapper.
- Crear consultas SQL directas.
- Implementar reportes o consultas optimizadas.
- Complementar EF Core con lecturas especializadas.
- Comparar EF vs Dapper desde un punto de vista práctico.

Ubicación propuesta:

```text
exercises/R2-CleanAPI
```

Plan mínimo:

```http
GET /api/Reports/employees-by-department
GET /api/Reports/bonus-summary
```

Defensa técnica esperada:

```text
Entity Framework se usa para operaciones transaccionales y persistencia general.
Dapper se usa para reportes y consultas SQL directas donde se requiere mayor control sobre joins, agregaciones y rendimiento.
```

---

### R5 - Angular + API REST

Estado: pendiente / reducido.

Objetivo:

- Crear una UI Angular básica.
- Consumir API REST.
- Listar empleados.
- Consultar departamentos.
- Crear empleados desde formulario.
- Mostrar errores del API.

Nota: debido a restricción de tiempo, este módulo puede resolverse en versión corta o dejarse como repaso conceptual, ya que la prioridad actual es reforzar Dapper, Docker y Azure.

---

### R6 - Microservicio completo con Docker y preparación Azure

Estado: pendiente / prioritario.

Objetivo:

- Agregar Dockerfile para la API.
- Crear docker-compose conceptual con API y SQL Server.
- Documentar variables de entorno.
- Preparar explicación de despliegue hacia Azure Container Apps.
- Documentar cómo se integraría Azure Service Bus.
- Documentar una estrategia básica de Azure DevOps pipeline.

Entregables mínimos esperados:

```text
Dockerfile
docker-compose.yml
README de despliegue
Notas de Azure Container Apps
Notas de Azure Service Bus
Notas de Azure DevOps
```

---

### R7 - Simulacro PROCOMER

Estado: pendiente.

Objetivo:

- Resolver un ejercicio completo contra reloj.
- Generar análisis, prototipo, implementación, pruebas y defensa oral.
- Practicar una entrega funcional en tiempo limitado.

Versión recomendada por tiempo disponible:

```text
30 min análisis
30 min diseño / casos de uso
60-90 min implementación base
30 min pruebas y defensa oral
```

---

## Estructura actual del repositorio

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

Nota: R2, R3, R4 y parte de R6 reutilizan el proyecto `R2-CleanAPI` para evolucionar progresivamente la misma solución backend.

---

## Comandos útiles

### Ejecutar R1

```powershell
dotnet run --project .\exercises\R1-MvcJqueryAjax\EmployeeManagement.Web\EmployeeManagement.Web.csproj
```

### Ejecutar R2 / R3 / R4 API

```powershell
dotnet run --project .\exercises\R2-CleanAPI\EmployeeManagement.Api\EmployeeManagement.Api.csproj
```

### Compilar y probar R1

```powershell
dotnet build .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln
dotnet test .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln
```

### Compilar y probar R2 / R3 / R4

```powershell
dotnet build .\exercises\R2-CleanAPI\EmployeeManagement.sln
dotnet test .\exercises\R2-CleanAPI\EmployeeManagement.sln
```

### Crear migración EF

```powershell
dotnet ef migrations add InitialCreate --project .\EmployeeManagement.Infrastructure\EmployeeManagement.Infrastructure.csproj --startup-project .\EmployeeManagement.Api\EmployeeManagement.Api.csproj --output-dir Persistence\Migrations
```

### Aplicar migración EF

```powershell
dotnet ef database update --project .\EmployeeManagement.Infrastructure\EmployeeManagement.Infrastructure.csproj --startup-project .\EmployeeManagement.Api\EmployeeManagement.Api.csproj
```

### Crear branch de trabajo

```powershell
git checkout -b r4-dapper-reports
```

### Mergear branch hacia master

```powershell
git checkout master
git merge <nombre-del-branch>
```

---

## Validación rápida del repositorio

Desde la raíz del repositorio:

```powershell
cd C:\ProcomerPractice
```

Ejecutar:

```powershell
dotnet build .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln
dotnet test .\exercises\R1-MvcJqueryAjax\EmployeeManagement.sln

dotnet build .\exercises\R2-CleanAPI\EmployeeManagement.sln
dotnet test .\exercises\R2-CleanAPI\EmployeeManagement.sln
```

Si Windows bloquea DLLs generadas durante los tests, revisar la configuración de seguridad del sistema. En este entorno se detectó que el **Control inteligente de aplicaciones** podía bloquear ensamblados generados por `dotnet test`.

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

## Defensa técnica resumida

### Clean Architecture

```text
Domain contiene las reglas puras del negocio.
Application orquesta casos de uso y define contratos.
Infrastructure implementa acceso a datos y detalles técnicos.
Api expone endpoints REST.
```

### EF Core

```text
Se utiliza para persistencia principal, migraciones, relaciones y operaciones transaccionales sobre SQL Server.
```

### Dapper

```text
Se utiliza para reportes o consultas SQL directas donde conviene controlar manualmente joins, agregaciones y rendimiento.
```

### Docker / Azure

```text
La API puede contenerizarse con Docker y desplegarse en Azure Container Apps.
La configuración sensible debe manejarse mediante variables de entorno o secretos.
Azure Service Bus puede usarse para comunicación asíncrona entre microservicios.
Azure DevOps puede automatizar build, test y despliegue.
```

---

## Regla principal

Primero funcionalidad correcta.  
Después limpieza.  
Después optimización.

Una solución simple, funcional, con arquitectura clara y pruebas básicas puntúa mejor que una solución ambiciosa pero incompleta.