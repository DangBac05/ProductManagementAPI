using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Behaviors;
using ProductManagementAPI.Data;
using ProductManagementAPI.Features.Products.Commands;
using ProductManagementAPI.Mappings;
using ProductManagementAPI.Middleware;
using ProductManagementAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateProductCommand>());

// Transaction Behavior
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(TransactionBehavior<,>)
);

// Validation Behavior
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

// FluentValidation
builder.Services.AddScoped<
    IValidator<CreateProductCommand>,
    CreateProductValidator>();

builder.Services.AddScoped<
    IValidator<UpdateProductCommand>,
    UpdateProductValidator>();

// EF Core + Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(
        builder.Configuration.GetConnectionString("OracleConnection")
    )
);

// Dapper
builder.Services.AddScoped<DapperContext>();

// AutoMapper
builder.Services.AddAutoMapper(
    cfg => { },
    typeof(MappingProfile).Assembly
);

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// HTTPS Redirection
// app.UseHttpsRedirection();

// Exception Handling Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();