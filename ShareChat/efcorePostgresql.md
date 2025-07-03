# 🚀 Entity Framework Core with PostgreSQL — Complete Setup Guide

This document provides a complete, step-by-step setup for using **Entity Framework Core (EF Core)** with a **PostgreSQL** database in a .NET project.

---

## 📦 Required NuGet Packages

Open a terminal in the root of your **startup project** (e.g., `ShareChat`) and run:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

### * Microsoft.EntityFrameworkCore.Design : 
Required for EF Core CLI tools like dotnet ef.

| Package                                     | Purpose                                                   |
|---------------------------------------------|-----------------------------------------------------------|
| `Microsoft.EntityFrameworkCore`             | Core EF functionality (`DbContext`, `DbSet`, LINQ`, etc.) |
| `Microsoft.EntityFrameworkCore.Design`      | Design-time tools (used for migrations and scaffolding)   |
| `Npgsql.EntityFrameworkCore.PostgreSQL`     | EF Core database provider for PostgreSQL                  |


#### appsetting.json
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=myDb;Username=user;Password=password"
  }
}
```

#### program.cs
```
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// other middleware and endpoints
app.Run();
```

## Create Migration
```
dotnet ef migrations add InitialCreate
```
##  Apply the Migration to the Database
```
dotnet ef database update
```

##  Common EF Core Commands
| Command                                 | Purpose                                           |
|-----------------------------------------|--------------------------------------------------|
| `dotnet ef migrations add <Name>`       | Create a new migration file                      |
| `dotnet ef database update`             | Apply all migrations to the database             |
| `dotnet ef migrations remove`           | Delete the last created migration (if unapplied) |
| `dotnet ef migrations list`             | List all applied migrations                      |
| `dotnet ef database update <Migration>` | Migrate to a specific version                    |
| `dotnet ef migrations script`           | Generate SQL script from migrations              |
| `dotnet ef database drop`               | Drop (delete) the database — asks for confirmation|

### What EF Core Does on ``dotnet ef database update``

| Step | Description |
|------|-------------|
| 1    | Connects to the PostgreSQL database using the connection string. |
| 2    | Creates the database if it does not already exist. |
| 3    | Applies all pending migrations. |
| 4    | Updates the schema (tables, columns, constraints, etc.) according to your model. |

