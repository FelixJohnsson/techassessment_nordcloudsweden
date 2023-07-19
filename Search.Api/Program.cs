using Microsoft.EntityFrameworkCore;
using Search.Api.DbModels;
using Search.Api.Handlers;
using Search.Api.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelContext>(options =>
{
    options.UseCosmos(connectionString: "", databaseName: "search");
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<Hotel>, HotelRepositoryMock>();
builder.Services.AddHealthChecks();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterSearchApis();
app.MapHealthChecks("/health");

app.Run();

public partial class Program { }