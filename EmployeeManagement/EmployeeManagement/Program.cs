using MediatR;
using System.Reflection;
using EmployeeManagement.Validators;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Handlers;
using EmployeeManagement.Models.Context;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddScoped<ValidateEmployeeExistance>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(builder.Configuration["Data:DefaultConnection:ConnectionString"]).EnableSensitiveDataLogging());

builder.Services.AddHttpClient("CustomHttpClient")
            .AddHttpMessageHandler<CustomDelegationHandler>();

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
