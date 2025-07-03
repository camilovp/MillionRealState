# 🏡 RealState API (.NET 9 - Clean Architecture)

**RealState** is a modular and scalable RESTful API built using **.NET 9**, applying **Clean Architecture** principles. It manages real estate properties, owners, images, and traceability, storing data in **MongoDB** and supporting file uploads.

---

## 📁 Project Structure

```
RealState/
├── src/
│   ├── Core/
│   │   ├── RealState.Application/   → Use Cases, DTOs, Interfaces
│   │   └── RealState.Domain/        → Domain Entities and Contracts
│   ├── Infrastructure/
│   │   └── RealState.Infrastructure/ → MongoDB + File Storage
│   └── WebApi/
│       └── RealState.Api/           → Controllers, Models, Swagger, Startup
└── test/
    └── RealState.Test/             → Unit Tests (NUnit)
```

---

## 🚀 Features

- CRUD operations for **Properties** and **Owners**
- Upload and serve **property images**
- **Sale trace** recording per property
- **Filtering** by owner, name, address, and price range
- Input validation with **Data Annotations**
- Project structured by **Clean Architecture**
- MongoDB integration
- File upload support (saved locally)
- Swagger UI for API documentation
- Unit tests using **NUnit**

---

## 🧱 Tech Stack

- [.NET 9](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- MongoDB
- Mapster (for DTO mapping)
- Swashbuckle (Swagger)
- NUnit (unit testing)
- Local file storage for images

---

## ⚙️ Configuration

Add your `appsettings.json` in `RealState.Api` project:

```json
{
  "MongoSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "RealState"
  }
}
```

---

## ▶️ Run the API

From the root folder:

```bash
dotnet run --project src/WebApi/RealState.Api
```

Swagger UI will be available at:

```
https://localhost:{port}/swagger
```

---

## 🧪 Run Unit Tests

```bash
dotnet test test/RealState.Test
```
Casos probados:
- CreatePropertyUseCase:

-- ExecuteAsync_WithValidData_ReturnsCreatedProperty

-- ExecuteAsync_RepositoryFails_ReturnsNull

-- ExecuteAsync_RepositoryThrowsException_Throws

- GetPropertyFilteredUseCase:

-- ExecuteAsync_WithMatchingFilters_ReturnsFilteredProperties

-- ExecuteAsync_NoMatchingFilters_ReturnsEmptyList

## 🖼 Property Images

Uploaded files are stored in:

```
src/WebApi/RealState.Api/PropertyImages/yyyyMMdd/
```

Example URL:

```
https://localhost:{port}/PropertyImages/20250703/filename.jpg
```

These folders are ignored in Git via `.gitignore`.

---

## 📄 .gitignore Notes

Make sure the following is included in your `.gitignore`:

```gitignore
# Ignore uploaded images
**/PropertyImages/
```

---


## 👨‍💻 Author

**Cristian Vargas**  
Senior Full-Stack Developer (C#, .NET, React)  
Colombia 🇨🇴 | Clean Architecture Enthusiast

---

## ✅ License

This project is open-source and free to use under the MIT License.
