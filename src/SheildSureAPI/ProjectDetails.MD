# ShieldSure: Microservices Insurance Platform

## 📌 Project Overview
ShieldSure is a cloud-native insurance management system built with **.NET 10** and **Docker**. The architecture follows **Clean Architecture** and **SOLID** principles, focusing on high availability and decoupled communication.

---

## 🛠 Tech Stack
- **Backend:** .NET 10 (Web API, Worker Services)
- **Database:** SQL Server 2022 (Dockerized)
- **Messaging:** RabbitMQ (MassTransit)
- **Security:** ASP.NET Core Identity + JWT (Stateless Auth)
- **Gateway:** YARP (Yet Another Reverse Proxy)
- **Testing:** xUnit + Moq (TDD Approach)

---

## 🏗 System Architecture & Progress

### 🟢 1. Identity Service (Status: Phase 1 Complete)
- **What we achieved:** - Containerized SQL Server setup.
    - Custom `ApplicationUser` using ASP.NET Identity.
    - JWT Generation logic with secure Signing Keys.
    - **Self-Correction:** Fixed JWT Audience typos and handled `async/await` Task unwrapping.
- **Interview Key Point:** "I implemented a stateless authentication system where the Identity service acts as the 'Passport Office' for the entire ecosystem."

### 🟡 2. API Gateway (Status: In Progress)
- **Current Goal:** implementing **YARP** to route traffic.
- **Why?** To hide internal microservice ports and provide a single entry point for the frontend.

### ⚪ 3. Policy & Claim Services (Status: Planned)
- **Goal:** Core business logic for insurance applications.

### ⚪ 4. Messaging & Notifications (Status: Planned)
- **Goal:** Use **RabbitMQ** to send a "Welcome Email" event when a user registers in Identity.

---

## 🧪 Testing Strategy
- **Unit Testing:** xUnit for business logic isolation.
- **TDD:** Following the Red-Green-Refactor cycle.
- **Mocking:** Using Moq to simulate dependencies like `IConfiguration`.

---

## 🚀 Key Commands Reference
### Setup
```bash
dotnet new sln -n ShieldSure
dotnet sln add (project_path)