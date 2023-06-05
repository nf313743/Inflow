using Inflow.Modules.Customers.Api;
using Inflow.Shared.Infrastructure;
using Inflow.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();
var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration, "Inflow.Modules.");
var modules = ModuleLoader.LoadModules(assemblies);

builder.Services.AddModularInfrastructure(builder.Configuration, assemblies);

foreach (var module in modules)
{
    module.Register(builder.Services, builder.Configuration);
}

var app = builder.Build();
{
    app.Logger.LogInformation($"Modules: {string.Join(", ", modules.Select(x => x.Name))}");

    foreach (var module in modules)
    {
        module.Use(app);
    }

    //app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapGet("/", () => "Hello World");
}

app.Run();
