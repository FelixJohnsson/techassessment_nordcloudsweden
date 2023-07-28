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

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddTransient<IRepository<Hotel>, HotelRepositoryMock>();
}
else
{
    builder.Services.AddTransient<IRepository<Hotel>, HotelRepository>();
}

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.RegisterSearchApis();
app.MapHealthChecks("/health");

app.Run();

public partial class Program { }