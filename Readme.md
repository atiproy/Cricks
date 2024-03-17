# Cricket Scoring API 🌐

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQLite](https://img.shields.io/badge/sqlite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/postgresql-316192?style=for-the-badge&logo=postgresql&logoColor=white)

Cricks API is a robust and secure web application built with .NET 8.0, providing weather forecasts. It uses Entity Framework Core for data storage and JWT for authentication.

## Table of Contents

- [Features](#features)
- [API Endpoints](#api-endpoints)
- [Setup](#setup)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## 🚀 Features

- **JWT Authentication**: Secure authentication using JSON Web Tokens.
- **Role-based Authorization**: Access control with predefined user roles.
- **Entity Framework Core**: Support for multiple databases including SQLite, SQL Server, MySQL, and PostgreSQL.
- **Swagger UI**: Interactive API documentation and testing.

## 📚 API Endpoints

- `GET /WeatherForecast`: Returns a list of weather forecasts.

## 🛠️ Setup

### Prerequisites

- .NET 8.0 or later
- SQLite, SQL Server, MySQL, or PostgreSQL

### Installation

1. **Clone the repository**   
2. **Navigate to the project directory**
3. **Restore the packages**
4. **Run the application**


## 🎮 Usage

Once the application is running, you can access the Swagger UI at `http://localhost:5000/swagger`.

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check [issues page](https://github.com/atiproy/Cricks/issues). You can also take a look at the [contributing guide](https://github.com/atiproy/Cricks/CONTRIBUTING.md).

## 📝 License

This project is [MIT](https://choosealicense.com/licenses/mit/) licensed.

## 📧 Contact

Created by [@atiproy](https://github.com/atiproy) - feel free to contact me!

## 📖 Detailed Documentation

### WeatherForecastController

The `WeatherForecastController` is an API controller that provides weather forecasts. It has the following methods:

- `GET /WeatherForecast`: Returns a list of weather forecasts. This endpoint is secured and requires the user to have the "Owner" role.

### Authentication

The application uses JWT for authentication. The JWT is included in the `Authorization` header with the `Bearer` scheme.

### Authorization

The application uses role-based authorization. The `WeatherForecastController` requires the user to have the "Owner" role.

### Database

The application uses Entity Framework Core for data storage. The connection string is configured in the `appsettings.json` file. It supports multiple databases including SQLite, SQL Server, MySQL, and PostgreSQL.

### Swagger UI

The application includes Swagger UI for interactive API documentation and testing. You can access it at `http://localhost:5000/swagger` when the application is running.
