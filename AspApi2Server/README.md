# 🧠 ASP.NET Core Web API + EF Core — Starter Project

Пример базового проекта на ASP.NET Core с использованием Entity Framework Core, PostgreSQL или другой СУБД.

---

## 🚀 Быстрый старт

1. Клонируй репозиторий:
   
   ```bash
   git clone https://github.com/your-user/your-repo.git
   cd your-repo
   ```

2. Проверь строку подключения в appsettings.json

3. Применяй миграции:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. Запусти проект:

   ```bash
   dotnet run
   ```

# 🛠 Строки подключения (Connection Strings)
## 🐘 PostgreSQL (Npgsql)
   ```bash
   Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=yourpassword
   ```

## 🧱 SQL Server (Microsoft)
### С логином и паролем:

   ```bash
   Server=localhost;Database=mydb;User Id=sa;Password=yourpassword;
   ```

### С Windows-аутентификацией:

   ```bash
   Server=localhost;Database=mydb;Trusted_Connection=True;
   ```

## 📄 SQLite (файл)
   
   ```bash
   Data Source=mydb.db;
   ```

# 📦 Используемые пакеты
Microsoft.EntityFrameworkCore
Npgsql.EntityFrameworkCore.PostgreSQL
EFCore.NamingConventions
Swashbuckle.AspNetCore (для Swagger)
Microsoft.AspNetCore.Mvc

# 📌 Полезные команды EF Core   
### Добавить миграцию
   ```bash 
   dotnet ef migrations add НазваниеМиграции
   ```

### Применить миграции к БД
   ```bash
   dotnet ef database update
   ```

### Удалить последнюю миграцию (если не применена)
   ```bash
   dotnet ef migrations remove
   ```

# 🧾 Пример строки в appsettings.json
   ```bash
    {
        "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=yourpassword"
        },
        "Logging": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*"
    }
   ```
