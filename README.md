# techassessment_nordcloudsweden
Microservice setup for making tech assessment

## Get Started
There is minimum effort to run these services, but there are some minor things that is needed.

1. Fork the repository 
2. Clone it locally (replace the path with ypur account and repository name)
```
git clone https://github.com/YOUR-USERNAME/YOUR-REPOSITORY
```
https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository

3. Install .Net 7 - https://dotnet.microsoft.com/en-us/download/dotnet/7.0
4. Verify the installation, it should return a version 7.x.x
```
dotnet --version
```
5. Change the Connection String for the database used in Book.API in the file `Book.API/appsettings.Development.json.`
Set the `Data Source=**YOUR_DATABASE**;Initial Catalog=Book;Integrated Security=True`
If you don't have a database locally you can install one https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16
6. Run the Book.API form `CloudHotels/Book.API/`
```
dotnet run --launch-profile https
```
7. To find the API documentation, go to https://localhost:7243/swagger/
8. Run the Search.API form `CloudHotels/Search.API/`
```
dotnet run --launch-profile https
```
9. To find the API documentation, go to https://localhost:7243/swagger/
10. To run Price.API first make sure you have Azure Functions Core Tool or Azure Development package in Visual Stusio 2019 or above installed
If not follow the guide https://learn.microsoft.com/en-us/azure/azure-functions/functions-develop-local

### Book.Api
This project is using Entity Framework Core and to be able to get the data change the ConnectionString in appsettings.Development.json.
You need to have a sql database server locally or remote. LocalDb works fine.
When the app starts the database is seeded with hotels, rooms and bookings.

### Price.Api
This is a service without data repository but is Azure Function. To run it in your local environment please see
https://learn.microsoft.com/en-us/azure/azure-functions/functions-develop-local

### Search.Api
This project has a repository pattern and it's using a Mock as default. So no need to setup a Cosmos Db
