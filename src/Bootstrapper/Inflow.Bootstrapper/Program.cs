using Inflow.Modules.Customers.Api;
using Inflow.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCustomModule(builder.Configuration);
    builder.Services.AddModularInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    //app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseCustomerModule();
    app.MapControllers();
    app.MapGet("/", () => "Hello World");
}

app.Run();
