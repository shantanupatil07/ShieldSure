

cd Services/AuthService/src/AuthService.Application
dotnet add package MediatR --version 12.5.0
dotnet add reference ../AuthService.Domain
----
docker run --name identity-db-postgres-container -e POSTGRES_USER=identitydbuser -e POSTGRES_DB=identitydb -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
cd Services/AuthService/src/AuthService.Api
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Port=5432;Database=identitydb;Username=identitydbuser;Password=mysecretpassword"
---
dotnet ef migrations add InitialCreate --project AuthService/src/AuthService.Infrastructure --startup-project AuthService/src/AuthService.Api

dotnet ef database update --project AuthService/src/AuthService.Infrastructure --startup-project AuthService/src/AuthService.Api
docker exec -it identity-db-postgres-container psql -U identitydbuser -d identitydb
SELECT "Id", "Email", "FirstName", "LastName", "IsActive", "CreatedAt" FROM "AspNetUsers";