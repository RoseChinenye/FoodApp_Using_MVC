# Food App Using ASP.NET MVC 😃👓👓

## About 👓

This is a simple implementation of a Food App using ASP.NET MVC.

---
## What the App Does 👓

- Anonymous Users can view the application
- Admin can Add a meal to the Menu, Edit a food item in the menu, View item in the menu and delete item from the menu.


N/B : All the changes made in the menu are persisted!

---
## Steps to Run 👓

Follow the following steps to successfully run and use this application.

**Paste your system's server name on the Connection String**
- Open the *FoodApp.MVC* project
- Open the *appsettings.json* file
- Edit the connection string and paste your system server name in the *Data Source* value of the *DefaultConn* key.
```C#
{
  "ConnectionString": {
    "DefaultConn": "Data Source=(paste your system server name here);Initial catalog=FoodAppDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
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
- Save

4. **Run the program**

---
## Packages Installed 👓


- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Mvc.ViewFeatures
- Microsoft.AspNetCore.Http.Abstractions
- System.ComponentModel.Annotations

---
## Software Development Summary 👓

- Technology: C#, EF CORE & ASP.Net MVC
- Console App Framework: .NET6
- Project Type: Class Library
- Class Library Framework: .Net standard 6.0
- IDE: Visual Studio (Version 2022)
- Paradigm or pattern of programming: Object-Oriented Programming (OOP)


NOTE: This repo is subject to future modifications.
