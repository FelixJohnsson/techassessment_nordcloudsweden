using Book.Api.Behaviors;
using Book.Api.Context;
using Book.Api.Endpoints;
using Book.Api.Migrations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblyContaining<Program>();
    configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

builder.Services.AddDbContext<HotelContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));

//Services
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(options =>
    {
        options.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseExceptionHandler(e =>
{
    e.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = Application.Json;
        
        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

        var problemDetails = new ProblemDetails
        {
            Title = $"An unhandled exception occurred while processing the request",
            Detail = exceptionHandlerPathFeature?.Error.Message,
            Status = StatusCodes.Status500InternalServerError
        };

        await context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(problemDetails));
    });
});

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.AddHotelsEndpoints();
app.AddRoomEndpoints();
app.AddBookingEndpoints();

app.Run();

public partial class Program { }