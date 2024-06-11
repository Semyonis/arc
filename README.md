# Arc

[![Build Status](https://github.com/Semyonis/arc/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Semyonis/arc/actions)

## Overview

Arc is a comprehensive .NET application framework designed for modularity, scalability, and ease of use. The project
encompasses a wide range of functionalities, including administrative operations, user management, data conversion, and
complex querying. It integrates seamlessly with various external systems such as RabbitMQ, Redis, and identity
management services.

## Features

- **Modular Design**: Clear separation of concerns with distinct namespaces for different functionalities.
- **Advanced Query Capabilities**: Robust criteria system for filtering, comparison, and parameterization.
- **Extensive Use of Entity Framework**: Simplifies data access and supports LINQ queries, change tracking, and schema
migrations.
- **CI/CD Integration**: Automated workflows for continuous integration and deployment.
- **Custom Middleware**: Centralized handling of requests, responses, logging, and exception management.
- **Containerization**: Docker support for consistent deployment across environments.
- **Testing**: Comprehensive unit and integration tests to ensure reliability.

## Table of Contents

- [Development Setup](#development-setup)
- [Running the Application](#running-the-application)
- [Running the Application in Docker](#running-the-application-in-docker)
- [Environment Variables](#environment-variables)
- [Project Structure](#project-structure)

## Development Setup

To get started with Arc, clone the repository and build the project using the .NET SDK.

```sh
git clone https://github.com/Semyonis/arc.git
cd arc
dotnet build
```

Ensure you have the .NET SDK installed. Run the following command to restore dependencies and build the project:

```sh
dotnet restore
dotnet build
```
To run the tests, use the following command:

```sh
dotnet test
```

## Running the Application

It's important to have installed on your machine 
- MySql (v8.0) (https://www.mysql.com/downloads/)
- RabbitMq (v3.12.10) (https://www.rabbitmq.com/docs/download)
- Redis (v7.2.3) (https://redis.io/downloads/)

After setting up dependencies it's important to create and apply Migrations to DB by start up **Migration** project.  

```sh
cd Arc.Executable.Migration
dotnet run
```

You can run the application using the .NET CLI:

If you executed previous command to setup DB you need to go back to previous directory by next command:

```sh
cd ..
```

Next you can run web api service

```sh
cd Arc.Executable.WebApi
dotnet run
```

To test the API, you can send a request to the endpoints through swagger ui at http://localhost:8080/index.html

## Running the Application in Docker

Alternatively, you can use Docker to run the application simply by executing next command:

```sh
 docker compose up
```

To test the API, you can send a request to the endpoints through swagger ui at http://localhost:8081/index.html

## Environment Variables

The application uses environment variables to manage configuration settings. For development purpose variables can be
set in **appsettings.Development.json** file at the root of the **Arc.Executable.*** projects or directly in your
environment. Below listed groups of variables used in the projects:

- **Database**: Specifies the environment in which the application is running (e.g., Development, Staging, Production).
- **Jwt**: Specifies the environment in which the application is running (e.g., Development, Staging, Production).
- **Logging**: The connection string for the default database.
- **RedisStack**: The logging level for the application (e.g., Information, Debug, Warning, Error).
- **RabbitMq**: The hostname or IP address of the RabbitMQ server.
- **Kestrel**: The connection string for the Redis cache.

## Project Structure

The project is organized into the following namespaces:

- **Arc.Controllers**: Handles API endpoints and request routing.
- **Arc.Converters**: Manages data transformations between different layers and formats.
- **Arc.Criteria**: Provides advanced query capabilities, including filtering, comparison, and parameterization.
- **Arc.Database**: Defines the database context, entities, migrations, and related operations.
- **Arc.Dependencies**: Integrates external libraries and frameworks.
- **Arc.Executable**: Contains executable components like the Web API and migration utilities.
- **Arc.Facades**: Simplifies interfaces for complex subsystems.
- **Arc.Infrastructure**: Includes foundational components like caching, configuration settings, exception handling,
and repositories.
- **Arc.Tests**: Contains unit and integration tests.
