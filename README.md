# Inventory Management System

![C#](https://img.shields.io/badge/C%23-.NET%208-blue?logo=csharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-purple)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green)
![SignalR](https://img.shields.io/badge/SignalR-Real--Time-orange)
![Docker](https://img.shields.io/badge/Docker-Supported-2496ED?logo=docker&logoColor=white)
![Status](https://img.shields.io/badge/Status-Completed-brightgreen)

An **ASP.NET Core MVC** web application developed to efficiently manage products, inventory, and customer orders. The system incorporates **ASP.NET Core Identity** for authentication, **Role-Based Authorization** for secure access control, **Entity Framework Core** for database operations, **SignalR** for real-time notifications, and follows the **Repository Pattern** to ensure a modular, maintainable, and scalable architecture.

---

# Overview

The Inventory Management System provides a centralized platform for managing products, inventory, and customer orders. Built using modern .NET technologies, the application demonstrates software engineering best practices through MVC architecture, repository pattern, dependency injection, authentication, authorization, real-time communication, and database-driven CRUD operations.

---

# Highlights

- ASP.NET Core MVC web application
- ASP.NET Core Identity authentication
- Role-based authorization
- Entity Framework Core
- Repository Pattern
- Dependency Injection
- SignalR real-time notifications
- SQL Server integration
- Dockerized deployment
- CRUD operations for products and orders

---

# Features

## Inventory & Product Management

- Add new products.
- View available inventory.
- Update product information.
- Delete products.
- Monitor product stock.

### Order Management

- Create customer orders.
- Manage order items.
- View order details.
- Automatically update inventory during order processing.

### Authentication & Authorization

- User registration and login.
- Secure authentication using ASP.NET Core Identity.
- Role-based authorization for administrators and users.
- Protected application routes.

### Real-Time Notifications

- Live inventory alerts using SignalR.
- Instant notification updates without page refresh.

### Architecture

- MVC Architecture
- Repository Pattern
- Dependency Injection
- Entity Framework Core
- Modular and maintainable codebase

---

# Technologies Used

| Category | Technology |
|----------|------------|
| Language | C# |
| Framework | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Authentication | ASP.NET Core Identity |
| Authorization | Role-Based Authorization |
| Real-Time Communication | SignalR |
| Architecture | MVC Architecture |
| Design Pattern | Repository Pattern |
| Dependency Injection | Built-in .NET Dependency Injection |
| Frontend | Razor Views |
| Deployment | Docker |

---

# Project Structure

```text
InventoryManagementSystem/
│
├── Areas/
│   └── Identity/
├── Controllers/
├── Data/
├── Hubs/
├── Migrations/
├── Models/
│   ├── Interfaces/
│   └── Repositories/
├── Views/
├── wwwroot/
│
├── Program.cs
├── appsettings.json
├── IMSIdentity.csproj
├── IMSIdentity.sln
├── Dockerfile
└── README.md
```

---

# System Architecture

```text
                    Client Browser
                          │
                          ▼
                 ASP.NET Core MVC
                          │
      ┌───────────────────┼───────────────────┐
      ▼                   ▼                   ▼
 Controllers         Razor Views        SignalR Hub
      │
      ▼
 Repository Layer
      │
      ▼
 Entity Framework Core
      │
      ▼
 SQL Server Database
```

---

# Core Modules

- Product Management
- Inventory Management
- Order Management
- User Authentication
- Role-Based Authorization
- Real-Time Notifications

---

# Software Engineering Concepts

This project demonstrates the implementation of:

- ASP.NET Core MVC
- Repository Pattern
- Entity Framework Core
- ASP.NET Core Identity
- Dependency Injection
- SignalR
- Object-Oriented Programming (OOP)
- CRUD Operations
- Role-Based Authorization
- Modular Software Design

---

# How to Run

### Option 1 – Run Locally

1. Clone the repository.

```bash
git clone https://github.com/hoorialaiba/IMS.git
```

2. Open the solution in Visual Studio.

3. Configure the SQL Server connection string in `appsettings.json` if required.

4. Apply Entity Framework Core migrations.

```powershell
Update-Database
```

5. Build and run the application.

---

### Option 2 – Run Using Docker

Pull the application image:

```bash
docker pull 92514577868/imsidentity
```

Pull the SQL Server image:

```bash
docker pull 92514577868/mssql-server
```

Run the containers according to your Docker configuration.

Docker Hub Images:

- **Application:** https://hub.docker.com/r/92514577868/imsidentity
- **SQL Server:** https://hub.docker.com/r/92514577868/mssql-server

---

# Future Improvements

- Product image uploads.
- Inventory analytics dashboard.
- Low-stock email notifications.
- Advanced search and filtering.
- REST API for external integrations.
- Unit and integration testing.

---

# Author

**Hooria Laiba**

Software Engineering Graduate  
Punjab University College of Information Technology (PUCIT)

GitHub: https://github.com/hoorialaiba
