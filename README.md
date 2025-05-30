# 🎯 QuizApp – ASP.NET Core Clean Architecture

**QuizApp** is a web-based quiz platform built with **.NET 8**, following **Clean Architecture principles**, using **Entity Framework Core** for persistence and **xUnit** for full end-to-end test flow.

---

## 📌 Table of Contents

- [🚀 Features](#-features)
- [🧱 Project Structure](#-project-structure)
- [⚙️ Tech Stack](#-tech-stack)
- [🛠 How to Run](#-how-to-run)
- [🗄️ Database Setup](#-database-setup)
- [🧪 Run Tests](#-run-tests)
- [👤 Author](#-author)
- [🪪 License](#-license)

---

## 🚀 Features

- ✅ Take quizzes with multiple questions and options
- ✅ Submit answers and validate correctness
- ✅ View final result: correct count, total time, pass/fail
- ✅ Functional test that simulates a full quiz-taking experience

---

## 🧱 Project Structure


QuizApp/
├── QuizApp.Api // ASP.NET Core Web API
├── QuizApp.Application // DTOs, Services, Interfaces
├── QuizApp.Domain // Domain models and repository contracts
├── QuizApp.Infrastructure // EF Core DbContext and Repository Implementations
├── QuizApp.Api.Tests // xUnit End-to-End Test
└── quiz_app_er.sql // SQL file for DB schema + seed data


---

## ⚙️ Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- xUnit
- Clean Architecture

---

## 🗄️ Database Setup (SQL Server)

The schema and seed data are included in the SQL file:  
📄 `quiz_app_er.sql`

### ✅ Steps to set up using SQL Server Management Studio (SSMS)

1. Open `quiz_app_er.sql` in SSMS
2. Run the following lines **first** to create and switch to the database:

```sql
CREATE DATABASE QuizApp
GO

USE QuizApp
GO

3. Then press Ctrl + A to select the entire script and Execute (F5)
4. ✅ This will create all necessary tables and insert sample data.

⚠️ If you skip step 2 and run the full script directly, you might see: 
Msg 911, Level 16, State 1
Database 'QuizApp' does not exist.

After setup, you will have the following tables:
User

Quiz

Question

Option

Answer

Result

## 🔧 Configure Connection String

After setting up the database, update your **connection string** in:

📄 `QuizApp.Api/appsettings.json`

### Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=QuizApp;User Id=sa;Password=your_password;TrustServerCertificate=True;"
}

 Key fields to check:
Server=: Name of your SQL Server instance (e.g., localhost\\SQLEXPRESS or just . for local)

Database=: Should be QuizApp (must match the database you created)

User Id= and Password=: If using SQL Authentication

TrustServerCertificate=true: Helps avoid SSL warnings in local development