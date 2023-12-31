# .Net API manage account for Apollo-Carter
The purpose of this API is to perform end-of-day balance calculations for each day in a set of transactions. It utilizes the current balance and transaction details as input and provides features such as calculating the total amounts of credits and debits.

# Project Structure

﻿# dotnet-template-onion

<p align="center">
  <img src="images/onion-ring-cqrs.png" alt="dotnet-template-onion logo" width="400"/>
</p>

A .NET/.NET Core template to use Onion Architecture and DDD (Domain Driven Design) with CQRS and ES with a simple example on how to use all this architecture together from the Controller until the Repository class using Domain objects and different patterns.

### Documentation

You can find information about this template in:

- [Main Architecture](docs/ARCHITECTURE.md)
- [Hexagonal Architecture](docs/HEXAGONAL.md)
- [DDD](docs/DDD.md)
- [CQRS AND ES](docs/CQRS-ES.md)
- [SOLID](docs/SOLID.md)

### Prerequisites

#### .NET 6

Ensure you have the correct dotnet-core SDK installed for your system:

https://dotnet.microsoft.com/download/dotnet/6.0

This is just the version used by the template, if you need to use a newer or older one, you can do it manually after.

### Usage

1. Clone this repository
2. Run dotnet restore to install the dependencies


### Structure of the project

```
C:.
│   .gitignore
│   Apollo-Carter.API.BankManager.sln
│   README.md
│
├───docs
│       ARCHITECTURE.md
│       CQRS-ES.md
│       DDD.md
│       HEXAGONAL.md
│       SOLID.md
│
├───images
│       dotnet-onion-ddd-cqrs-es.jpg
|       onion-ring-cqrs.png
│
├───src
│   ├───Apollo-Carter.API.BankManager.API
│   │   │   .dockerignore
│   │   │   Dockerfile
│   │   │   Apollo-Carter.API.BankManager.API.csproj
│   │   │   Program.cs
│   │   │   Startup.cs
│   │   │
│   │   ├───Bindings
│   │   ├───Config
│   │   │       appsettings-dev.json
│   │   │       appsettings-int.json
│   │   │       appsettings-prod.json
│   │   │       appsettings-stag.json
│   │   │
│   │   ├───Controllers
│   │   │       ApollosController.cs
│   │   │
│   │   ├───Extensions
│   │   │   └───Middleware
│   │   │           ErrorDetails.cs
│   │   │           ExceptionMiddleware.cs
│   │   │
│   │   └───Properties
│   │           launchSettings.json
│   │
│   ├───Apollo-Carter.API.BankManager.Application
│   │   │   Apollo-Carter.API.BankManager.Application.csproj
│   │   │
│   │   ├───Handlers
│   │   │       ApolloCommandHandler.cs
│   │   │       ApolloEventHandler.cs
│   │   │
│   │   ├───Mappers
│   │   │       ApolloViewModelMapper.cs
│   │   │
│   │   ├───Services
│   │   │       IApolloService.cs
│   │   │       ApolloService.cs
│   │   │
│   │   └───ViewModels
│   │           ApolloViewModel.cs
│   │
│   ├───Apollo-Carter.API.BankManager.Domain
│   │   │   Apollo-Carter.API.BankManager.Domain.csproj
│   │   │   IAggregateRoot.cs
│   │   │   IRepository.cs
│   │   │
│   │   └───Apollos
│   │       │   IApolloFactory.cs
│   │       │   IApolloRepository.cs
│   │       │   Apollo.cs
│   │       │
│   │       ├───Commands
│   │       │       CreateNewApolloCommand.cs
│   │       │       DeleteApolloCommand.cs
│   │       │       ApolloCommand.cs
│   │       │
│   │       ├───Events
│   │       │       ApolloCreatedEvent.cs
│   │       │       ApolloDeletedEvent.cs
│   │       │       ApolloEvent.cs
│   │       │
│   │       └───ValueObjects
│   │               Description.cs
│   │               Summary.cs
│   │               ApolloId.cs
│   │
│   └───Apollo-Carter.API.BankManager.Infrastructure
│       │   Apollo-Carter.API.BankManager.Infrastructure.csproj
│       │
│       ├───Factories
│       │       EntityFactory.cs
│       │       ApolloFactory.cs
│       │
│       └───Repositories
│               ApolloRepository.cs
│
└───tests
    └───Apollo-Carter.API.BankManager.Tests
        │   Apollo-Carter.API.BankManager.Tests.csproj
        │
        └───UnitTests
            ├───Application
            │   └───Services
            │           ApolloServiceTests.cs
            │
            └───Helpers
                    HttpContextHelper.cs
                    ApolloHelper.cs
                    ApolloViewModelHelper.cs



```
### References

```
Dotnet template:
https://github.com/pereiren/dotnet-template-onion
Aggregate:
https://martinfowler.com/bliki/DDD_Aggregate.html
```
