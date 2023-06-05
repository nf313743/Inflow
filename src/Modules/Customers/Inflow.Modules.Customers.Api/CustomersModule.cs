using Inflow.Modules.Customers.Core;
using Inflow.Modules.Customers.Core.DTO;
using Inflow.Modules.Customers.Core.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Inflow.Shared.Abstractions.Modules;
using Inflow.Shared.Abstractions.Queries;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Inflow.Bootstrapper")]
namespace Inflow.Modules.Customers.Api;

internal class CustomersModule : IModule
{
    public string Name { get; } = "Customers";

    public IEnumerable<string> Policies { get; } = new[]
    {
        "customers"
    };

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
    }

    public void Use(IApplicationBuilder app)
    {
        // app.UseModuleRequests()
        //     .Subscribe<GetCustomer, CustomerDetailsDto>("customers/get",
        //         (query, serviceProvider, cancellationToken)
        //             => serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));

        // app.UseContracts()
        //     .Register<SignedUpContract>()
        //     .Register<UserStateUpdatedContract>();
    }
}