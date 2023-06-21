## School System

Basic CRUD project for study purpose.

## Requirements
- .NET 6.0
- MySQL

## Install
1. Install mysql or just use a Docker image:

`$ docker run --network="host" -e MYSQL_ROOT_PASSWORD=senha123 -d mysql` 

connect to it and create a database named `db`.

> Note: Database name and password are hardcoded on `Data/SchoolSystemDbContext.cs` and `appsettings.json`

2. You need Dotnet EntityFramework library to run migrations:

`$ dotnet tool install --global dotnet-ef`

3. Update your database with migrations running:

`$ dotnet ef database update`

4. Run project (in hot reload mode):

`$ dotnet watch run ./Program.cs`