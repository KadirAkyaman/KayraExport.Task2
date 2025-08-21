# KayraExport.Task 2 - UserProductApi

[Click here for the Turkish version of this document.](./README.md)

This project is a **User and Product Management API** application developed for KayraExport. As a junior backend developer, I implemented basic CRUD operations, user management, and authentication in this project.

The purpose of this project is to provide user and product management operations through an API.

---

## Features and Implementations

### 1. **User and Product CRUD**
- Basic CRUD operations are implemented via `UserService` and `ProductService`.
- **UnitOfWork + Repository Pattern** is used for database operations.
- Supports creating, reading, updating, and deleting users and products.

### 2. **Authentication / JWT**
- Implemented **JWT-based authentication** for user login.
- Passwords are **hashed with BCrypt** before storing in the database.
- Token expiration, issuer, and audience are configured through **appsettings.json**.
- In previous projects (CinemaApi), JWT and Redis were used with online research and examples. However, as a junior developer, I implemented **JWT independently through research and available resources**, and Redis caching was not added in this project.

### 3. **DTOs and AutoMapper**
- Created DTOs for data transfer: `UserDto`, `ProductDto`, `AuthResponseDto`, `RegisterUserDto`, `LoginUserDto`, `CreateProductDto`, `UpdateProductDto`, `ProductDetailDto`.
- **AutoMapper** is used for entity-to-DTO and DTO-to-entity mapping.

### 4. **Validation / FluentValidation**
- DTOs are validated using **FluentValidation**:
  - `CreateProductDtoValidator`
  - `UpdateProductDtoValidator`
  - `RegisterUserDtoValidator`
  - `LoginUserDtoValidator`
- Required fields (e.g., Name, Email, Password, Stock, Description) are validated.
- Validation errors are returned to the client in JSON format through the **Global Exception Middleware**.

### 5. **Global Exception Handling**
- Centralized **ExceptionMiddleware** is implemented for the entire API.
- Handles `NotFoundException` and other general exceptions.
- FluentValidation errors are also returned via middleware.

### 6. **API Versioning**
- Endpoint versioning is supported (`v1`) and can be called using URL segments.
- Example: `/api/v1/products`

### 7. **Swagger**
- Swagger UI is integrated into the project. Documentation generation was limited due to time constraints.

---

## Project Status and Notes

- This project is designed for **junior-level backend development**, and basic features are fully implemented.
- JWT Authentication was added by **researching online resources and examples**. Although I used JWT and Redis in previous projects (CinemaApi), those projects involved more assistance. In this project, JWT was implemented independently.
- **Redis, CQRS, and MediatR** are **not implemented** as these are advanced topics beyond the junior level and not required for this project.
- Completed main features:
  - User, Product, and Auth controllers
  - UnitOfWork and Service layers
  - DTO mapping with AutoMapper
  - Global Exception Middleware
  - NotFoundException handling
  - API Versioning
  - DTO validation with FluentValidation
  - JWT Authentication
- This project serves as an implementation and testing exercise for a **junior backend developer**. Advanced features (Redis, CQRS, MediatR) may be added in the future.

---

## Unimplemented / Advanced Features
- **Redis Cache** not added (beyond junior level and unnecessary for this project).  
- **CQRS / MediatR** patterns are not yet applied.  
- Unit Tests or Integration Tests are not implemented.  

---

## Setup
1. Clone the repository:  
```bash
git clone https://github.com/KadirAkyaman/KayraExport.Task2
```

2. Create the database:
- Create a new PostgreSQL database.
- Update the DefaultConnection string in appsettings.json according to your database settings.

3. Apply migrations:
```bash
dotnet ef database update
```

4. Run the project:
```bash
dotnet run --project src/KayraExport.Api/KayraExport.Api.csproj
```