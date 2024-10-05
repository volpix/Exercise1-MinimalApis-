using Microsoft.Extensions.Options;
using MinimalApis.Model;
using MinimalApis.Services;
using MinimalApis.Services.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OperationSettings>(builder.Configuration.GetSection("OperationSettings"));

//Use Dependency injection Scoped
builder.Services.AddScoped<IOperationsService, OperationsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();



app.MapGet("/AllOperations",
    (int? a, int? b, IOptions<OperationSettings> settings, IOperationsService operationsService) =>
    {
        var defaultA = a ?? settings.Value.DefaultA;
        var defaultB = b ?? settings.Value.DefaultB;

        var additionResult = operationsService.Addition(defaultA, defaultB);
        var subtractionResult = operationsService.Subtraction(defaultA, defaultB);
        var multiplicationResult = operationsService.Multiplication(defaultA, defaultB);
        object divisionResult = defaultB != 0 ? (object)operationsService.Division(defaultA, defaultB) : "Division by zero is not allowed";

        var result = new
        {
            Addition = additionResult,
            Subtraction = subtractionResult,
            Multiplication = multiplicationResult,
            Division = divisionResult
        };

        return Results.Ok(result);
    })
.WithName("GetAllOperations")
.WithTags("Operations");

app.MapGet("/Addition", (int? a, int? b, IOptions<OperationSettings> settings, IOperationsService operationsService) =>
{
    var defaultA = a ?? settings.Value.DefaultA;
    var defaultB = b ?? settings.Value.DefaultB;

    var result = operationsService.Addition(defaultA, defaultB);
    return Results.Ok(result);
})
.WithName("Addition")
.WithTags("Operations");

app.MapGet("/Subtraction", (int? a, int? b, IOptions<OperationSettings> settings, IOperationsService operationsService) =>
{
    var defaultA = a ?? settings.Value.DefaultA;
    var defaultB = b ?? settings.Value.DefaultB;

    var result = operationsService.Subtraction(defaultA, defaultB);
    return Results.Ok(result);
})
.WithName("Subtraction")
.WithTags("Operations");

app.MapGet("/Division", (int? a, int? b, IOptions<OperationSettings> settings, IOperationsService operationsService) =>
{
    var defaultA = a ?? settings.Value.DefaultA;
    var defaultB = b ?? settings.Value.DefaultB;

    // Check for division by zero
    if (defaultB == 0)
    {
        return Results.BadRequest("Division by zero is not allowed.");
    }

    var result = operationsService.Division(defaultA, defaultB);
    return Results.Ok(result);
})
.WithName("Division")
.WithTags("Operations");

app.MapGet("/Multiplication", (int? a, int? b, IOptions<OperationSettings> settings, IOperationsService operationsService) =>
{
    var defaultA = a ?? settings.Value.DefaultA;
    var defaultB = b ?? settings.Value.DefaultB;

    var result = operationsService.Multiplication(defaultA, defaultB);
    return Results.Ok(result);
})
.WithName("Multiplication")
.WithTags("Operations");



app.Run();