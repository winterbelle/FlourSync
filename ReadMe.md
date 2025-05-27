# 🧁 FlourSync POS System

FlourSync is a Point-of-Sale (POS) system built for bakery businesses.  
Developed using **C#**, **.NET Core**, **MySQL**, and **MAUI**, FlourSync provides desktop/mobile functionality for managing bakery sales, inventory, and employee logins.

---

## 📦 Project Structure

FlourSync/

├── FlourSync.sln             # Main solution

├── FlourSync.API/            # .NET Core Web API (backend)

├── FlourSync.App/            # MAUI cross-platform frontend (mobile/tablet)

---

### ✅ Required Tools

Make sure you have the following installed:

* [Visual Studio 2022](https://visualstudio.microsoft.com/) with:

  * .NET 8 SDK
  * ASP.NET and web development workload
* [MySQL Server 8.x](https://dev.mysql.com/downloads/mysql/)
* [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (optional)
* Git

---

## 📦 NuGet Packages (With Correct Versions)

Run these inside the `FlourSync.API` folder:

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.13
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.13
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.3
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
```

> ⚠️ These versions **must match** to avoid build errors.
> ❌ Do **not upgrade** to EF Core 9 or Swashbuckle 6.6+ — it will break Pomelo compatibility.

---

## 🧪 Example `.csproj` Package Section

Ensure your `FlourSync.API.csproj` includes:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.13" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.13">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.3" />
  <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
</ItemGroup>
```

---

## 🔧 Configuration

### 1. Create the Database

In MySQL Workbench or CLI:

```sql
CREATE DATABASE FlourSync;
```

### 2. Update Your `appsettings.json`

Open `FlourSync.API/appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=FlourSyncDB;user=root;password=yourpassword;"
}
```

---

## 🏗️ Building and Running

### In Visual Studio 2022:

1. Open `FlourSync.sln`
2. Right-click `FlourSync.API` → **Set as Startup Project**
3. Press `Ctrl + Shift + B` to build
4. Press `F5` to run

---

## 🧱 Database Setup

### SQL Dump (provided)

Location: FourSync/Resouces/MySQLDump

***Do this command for each table***

```bash
mysql -u root -p FlourSyncDB < floursync_dump.sql
```

---

## 🔍 Testing the API

Once running, test endpoints using:

### ✅ Swagger UI Testing 

Visit:

```
https://localhost:[Port Number]/swagger
```

To find the port number to the following:

``` bash
dotnet run
```

Once it runs you should be able to see what port it running. To stop running the API simple do `CTRL + C`

## 💻 Postman Testing

Download Postman: https://www.postman.com/downloads/

Try the following endpoints:

| Method | Route             | Description         |
| ------ | ----------------- | ------------------- |
| GET    | `/api/products`      | Get all products    |
| POST   | `/api/products`      | Add a new product   |
| PUT    | `/api/products/{id}` | Update product info |
| DELETE | `/api/products/{id}` | Remove a product    |

---

## 📋 To-Do / In Progress

* [x] ItemsController
* [x] MySQL integration
* [ ] OrdersController
* [ ] Employee login logic
* [ ] Frontend integration with API
* [ ] Reporting functionality (Sales + Inventory)

---

## 🧑‍💻 Team Workflow (Important)

1. **Create a new branch** for any feature:

   ```bash
   git checkout -b feature-name
   ```

2. **Commit & push changes**:

   ```bash
   git add .
   git commit -m "Add [feature]"
   git push -u origin feature-name
   ```

3. **Create a Pull Request** on GitHub and tag the team

---

## 🙌 Team

Built with ☕ and 🍩 by the FlourSync Team – Spring 2025

* Blanca (Full Stack Lead / DB Admin)
* Karla (Frontend Developer)
* Alif (Research & Structure / Backend Developer)
* Nick (Backend Developer)

---

## 🛑 Git Reminders

* ✅ Add your MySQL credentials **locally** only — don’t push real passwords.
* ✅ `.vs/`, `bin/`, `obj/`, and user settings are ignored via `.gitignore`
* ✅ If Visual Studio locks files in `.vs/`, close it before switching branches.
* ✅ Please use environment variables or keep `appsettings.Development.json` locally.

---
