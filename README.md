# 🎯 QuizApp – ASP.NET Core Clean Architecture

**QuizApp** is a web-based quiz platform built with **.NET 8**, following **Clean Architecture principles**, using **Entity Framework Core** for persistence and **xUnit** for comprehensive testing.

---

## 📌 Table of Contents
- [🚀 Features](#-features)
- [🧱 Project Structure](#-project-structure)
- [⚙️ Tech Stack](#-tech-stack)
- [🛠 How to Run](#-how-to-run)
- [🗄️ Database Setup](#-database-setup)
- [🧪 Run Tests](#-run-tests)
- [👤 Author](#-author)
- [📄 License](#-license)

---

## 🚀 Features

- ✅ **Interactive Quiz System** - Take quizzes with multiple-choice questions
- ✅ **Real-time Validation** - Submit answers and get instant feedback
- ✅ **Comprehensive Results** - View detailed results including score, time taken, and pass/fail status
- ✅ **End-to-End Testing** - Full test coverage simulating complete user journey
- ✅ **Clean Architecture** - Maintainable and scalable codebase structure

---

## 🧱 Project Structure

```
QuizApp/
├── QuizApp.Api/                    # ASP.NET Core Web API
├── QuizApp.Application/            # Application Layer (DTOs, Services, Interfaces)
├── QuizApp.Domain/                 # Domain Layer (Entities, Repository Contracts)
├── QuizApp.Infrastructure/         # Infrastructure Layer (EF Core, Repositories)
├── QuizApp.Api.Tests/             # xUnit End-to-End Tests
└── quiz_app_er.sql                # Database Schema & Seed Data
```

---

## ⚙️ Tech Stack

- **Framework**: .NET 8
- **Web API**: ASP.NET Core
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Testing**: xUnit
- **Architecture**: Clean Architecture Pattern

---

## 🗄️ Database Setup

### Prerequisites
- SQL Server (LocalDB, Express, or Full version)
- SQL Server Management Studio (SSMS) or Azure Data Studio

### Setup Instructions

1. **Create Database First**
   ```sql
   CREATE DATABASE QuizApp
   GO
   USE QuizApp
   GO
   ```

2. **Execute Schema Script**
   - Open `quiz_app_er.sql` in SSMS
   - Select all content (Ctrl + A)
   - Execute the script (F5)

3. **Verify Setup**
   After successful execution, you should have these tables:
   - `User` - User management
   - `Quiz` - Quiz definitions
   - `Question` - Quiz questions
   - `Option` - Answer options
   - `Answer` - User responses
   - `Result` - Quiz results

> ⚠️ **Important**: Always create the database first before running the full script to avoid "Database does not exist" errors.

---

## 🔧 Configuration

### Connection String Setup

Update your connection string in `QuizApp.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=QuizApp;User Id=sa;Password=your_password;TrustServerCertificate=True;"
  }
}
```

### Connection String Parameters

| Parameter | Description | Example |
|-----------|-------------|---------|
| `Server` | SQL Server instance | `localhost\\SQLEXPRESS` or `.` |
| `Database` | Database name | `QuizApp` |
| `User Id` | SQL Authentication username | `sa` |
| `Password` | SQL Authentication password | `your_password` |
| `TrustServerCertificate` | Skip SSL validation (dev only) | `True` |

### Alternative Connection Strings

**Windows Authentication:**
```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=QuizApp;Trusted_Connection=true;TrustServerCertificate=True;"
```

**LocalDB:**
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=QuizApp;Trusted_Connection=true;"
```

---

## 🛠 How to Run

### 1. Clone the Repository
```bash
git clone <repository-url>
cd QuizApp
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Set Up Database
Follow the [Database Setup](#-database-setup) instructions above.

### 4. Update Connection String
Configure your connection string in `appsettings.json`.

### 5. Run the Application
```bash
cd QuizApp.Api
dotnet run
```

The API will be available at:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger UI**: `https://localhost:5001/swagger`

---

## 🧪 Run Tests

### How to Run Tests in Visual Studio

1. **Open Test Explorer**
   - Go to **View** → **Test Explorer** (or press `Ctrl+E, T`)

2. **Run Tests**
   - Right-click on the solution/project → **Run Tests**
   - Or click **Run All Tests** in Test Explorer

![Run Tests in Visual Studio](https://github.com/user-attachments/assets/19ba315a-0804-477e-88b0-d3c267054889)

3. **View Test Results and Logs**
   - Click on **FullQuizFlow_ShouldReturnResult** test to see detailed execution log
   - Expand test details to view complete quiz flow execution

![Test Explorer Results](https://github.com/user-attachments/assets/499d23e1-35be-45b5-8e62-540b64f8f6c4)

### Alternative: Command Line

```bash
# Execute all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Watch mode (auto-run on file changes)
dotnet test --watch
```

### Test Coverage
The test suite includes:
- ✅ **End-to-end API testing** - Complete request/response flow
- ✅ **Database integration tests** - Real database operations
- ✅ **Complete user journey simulation** - Full quiz-taking experience
- ✅ **Response validation** - JSON structure and data validation
- ✅ **Error handling tests** - Exception scenarios and edge cases

### What the Test Log Shows:
- ✅ **Step 1**: Fetching quiz questions from API
- ✅ **Quiz Details**: "Developer Basics Quiz" with 10 questions  
- ✅ **Q1-Q10**: Each question with answer validation
- ✅ **Submission**: Quiz answers submitted successfully
- ✅ **Final Result**: 
  - **Correct**: 5 out of 10 answers
  - **Time**: 427 seconds
  - **Status**: ✅ **PASSED**

This comprehensive test validates the entire user journey from quiz start to result display, ensuring all API endpoints work correctly together.

---

## 🏗️ Architecture Overview

### Clean Architecture Layers

1. **Domain Layer** (`QuizApp.Domain`)
   - Core business entities
   - Repository interfaces
   - Domain logic

2. **Application Layer** (`QuizApp.Application`)
   - Application services
   - DTOs and mapping
   - Business rules

3. **Infrastructure Layer** (`QuizApp.Infrastructure`)
   - Data access implementation
   - External service integrations
   - EF Core DbContext

4. **Presentation Layer** (`QuizApp.Api`)
   - Web API controllers
   - Request/Response handling
   - Dependency injection setup

---

## 🔍 Development Notes

### Key Features
- **Dependency Injection** - Proper IoC container setup
- **Repository Pattern** - Abstracted data access
- **DTO Pattern** - Clean data transfer objects
- **Exception Handling** - Centralized error management
- **Logging** - Comprehensive application logging

### Best Practices Implemented
- ✅ Separation of concerns
- ✅ SOLID principles
- ✅ Clean code practices
- ✅ Comprehensive testing
- ✅ Proper error handling

---

## 👤 Author

**Hoàng Đức Hiền**
- Email: hoangduchien2002@gmail.com

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

*Built with ❤️ using .NET 8 and Clean Architecture principles*
