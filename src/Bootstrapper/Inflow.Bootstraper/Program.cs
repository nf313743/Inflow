using Inflow.Modules.Customers.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomModule();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCustomerModule();

app.MapControllers();

app.MapGet("/", () => "Hello World");

app.Run();
