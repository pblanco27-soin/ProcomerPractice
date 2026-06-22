FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY EmployeeManagement.slnx ./

COPY EmployeeManagement.Domain/EmployeeManagement.Domain.csproj EmployeeManagement.Domain/
COPY EmployeeManagement.Application/EmployeeManagement.Application.csproj EmployeeManagement.Application/
COPY EmployeeManagement.Infrastructure/EmployeeManagement.Infrastructure.csproj EmployeeManagement.Infrastructure/
COPY EmployeeManagement.Api/EmployeeManagement.Api.csproj EmployeeManagement.Api/
COPY EmployeeManagement.Tests/EmployeeManagement.Tests.csproj EmployeeManagement.Tests/

RUN dotnet restore EmployeeManagement.slnx

COPY . .

RUN dotnet publish EmployeeManagement.Api/EmployeeManagement.Api.csproj \
    -c Release \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "EmployeeManagement.Api.dll"]