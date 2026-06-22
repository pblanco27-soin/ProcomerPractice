# Azure deployment notes

## Objetivo

Este documento describe cómo se podría desplegar la solución Employee Management API en Azure usando contenedores y servicios administrados.

La solución actual incluye:

- ASP.NET Core Web API.
- Clean Architecture.
- SQL Server.
- Entity Framework Core.
- Dapper.
- Dockerfile multi-stage.
- docker-compose local para API + SQL Server.

---

## Azure Container Apps

La API puede desplegarse en Azure Container Apps siguiendo este flujo:

1. Construir la imagen Docker de la API.
2. Publicar la imagen en Azure Container Registry.
3. Crear un Azure Container App usando esa imagen.
4. Configurar variables de entorno.
5. Configurar secretos para connection strings.
6. Exponer el endpoint público HTTPS.

Ejemplo conceptual:

```text
Developer machine / CI pipeline
        |
        v
Docker build
        |
        v
Azure Container Registry
        |
        v
Azure Container Apps
        |
        v
EmployeeManagement.Api
```

---

## Configuración

La API no debe tener connection strings quemados en código.

En local se usa:

```json
{
  "ConnectionStrings": {
    "EmployeeManagementDb": "..."
  }
}
```

En contenedor se usa variable de entorno:

```text
ConnectionStrings__EmployeeManagementDb
```

En Azure Container Apps se configuraría como secreto o variable de entorno segura.

---

## SQL Server en Azure

Para ambiente productivo, la base de datos debería estar en:

```text
Azure SQL Database
```

La API se conectaría mediante connection string seguro.

Las migraciones EF podrían ejecutarse de estas formas:

1. Manualmente desde pipeline.
2. Como paso controlado de despliegue.
3. Desde una herramienta administrativa.
4. No automáticamente al iniciar el contenedor en producción.

---

## Azure Service Bus

Azure Service Bus puede usarse para comunicación asíncrona entre microservicios.

Ejemplo:

```text
EmployeeManagement.Api
        |
        v
Publishes EmployeeCreated event
        |
        v
Azure Service Bus Queue / Topic
        |
        v
Notification service / Reporting service / Audit service
```

Caso de uso:

Cuando se crea un empleado, la API podría publicar un evento:

```json
{
  "eventName": "EmployeeCreated",
  "employeeId": 10,
  "email": "employee@empresa.com"
}
```

Otro servicio podría consumir ese evento para:

- Enviar notificación.
- Actualizar reportes.
- Registrar auditoría.
- Integrarse con sistemas externos.

---

## Azure DevOps

Un pipeline básico de Azure DevOps podría hacer:

1. Restaurar dependencias.
2. Compilar solución.
3. Ejecutar pruebas.
4. Construir imagen Docker.
5. Publicar imagen en Azure Container Registry.
6. Desplegar en Azure Container Apps.

Ejemplo conceptual:

```text
Pull Request / Commit
        |
        v
dotnet restore
        |
        v
dotnet build
        |
        v
dotnet test
        |
        v
docker build
        |
        v
docker push
        |
        v
deploy to Azure Container Apps
```

---

## Seguridad

Buenas prácticas:

- No guardar contraseñas en el repositorio.
- Usar secretos de Azure Container Apps.
- Usar Azure Key Vault para secretos sensibles.
- Usar HTTPS.
- Limitar acceso a base de datos.
- Usar identidad administrada cuando sea posible.
- Separar configuración por ambiente: Development, QA, Production.

---

## Defensa técnica

La solución está preparada para contenedores mediante un Dockerfile multi-stage.

La etapa de build usa el SDK de .NET para restaurar, compilar y publicar.

La etapa runtime usa una imagen ASP.NET más liviana para ejecutar la API.

Docker Compose se usa localmente para levantar la API y SQL Server.

En Azure, la imagen se publicaría en Azure Container Registry y se ejecutaría en Azure Container Apps, configurando connection strings mediante variables de entorno o secretos.

Para comunicación asíncrona entre microservicios, se podría integrar Azure Service Bus usando eventos como EmployeeCreated.

Para CI/CD, Azure DevOps puede automatizar build, test, docker build, push y deploy.