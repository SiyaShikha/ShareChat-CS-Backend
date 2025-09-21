# ShareChat

ShareChat is a chat application built with **ASP.NET Core**, **Entity Framework Core**, and **PostgreSQL**.  
It provides functionality for managing users, chat rooms, and messages.

---

## 📂 Project Structure

```
├── Controllers/      [API controllers]
├── Data/             [Database context]
├── DTOs/             [Data Transfer Objects]
├── Hubs/             [SignalR hubs]
├── Migrations/       [EF Core migration files]
├── Models/           [Entity models]
├── Repositories/     [Repository classes]
├── Scripts/          [Shell scripts for database migrations]
├── Services/         [Business logic services]
├── Utils/            [Utility classes]
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── ShareChat.csproj
```


---

## 🚀 Setup Instructions

1. **Clone the repository**:
    ```bash
    git clone <repository-url>
    cd ShareChat
    ```
2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```
3. **Set executable permission for migration scripts (only needed once)**:
    ```bash
    chmod +x Scripts/*.sh
    ```

## 🗄️ Database Migrations

The project uses Entity Framework Core for migrations with PostgreSQL.
The following scripts are provided inside the **Scripts/** folder:
1. **Initial Migration** `
    ```bash 
    ./Scripts/initial-migration.sh
    ```
2. **Update Migration**
    ```bash 
    ./Scripts/update-migration.sh
    ```
3. **Add Migration**
    ```bash 
    ./Scripts/add-migration.sh <MigrationName>
    ```
   
⚠️ Make sure your PostgreSQL connection string is correctly configured in
appsettings.json or appsettings.Development.json.

## ▶️ Running the Application
```
dotnet run
```
