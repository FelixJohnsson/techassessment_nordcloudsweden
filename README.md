# techassessment_nordcloudsweden
Microservice setup for making tech assessment

## Get Started
There is minimum effort to run these services, but there are some minor things that is needed.

### Book.Api
This project is using Entity Framework Core and to be able to get the data change the ConnectionString in appsettings.Development.json.
You need to have a sql database server locally or remote. LocalDb works fine.
When the app starts the database is seeded with hotels, rooms and bookings.

### Price.Api
This is a service without data repository but is Azure Function. To run it in your local environment please see
https://learn.microsoft.com/en-us/azure/azure-functions/functions-develop-local

### Search.Api
This project has a repository pattern and it's using a Mock as default. So no need to setup a Cosmos Db
