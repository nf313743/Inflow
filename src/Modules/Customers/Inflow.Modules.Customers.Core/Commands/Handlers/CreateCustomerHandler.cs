using Inflow.Modules.Customers.Core.Domain.Entities;
using Inflow.Modules.Customers.Core.Domain.Repositories;
using Inflow.Shared.Abstractions.Commands;
using Inflow.Shared.Abstractions.Kernel.ValueObjects;
using Inflow.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace Inflow.Modules.Customers.Core.Commands.Handlers;

internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomer>
{
    private readonly ILogger<CreateCustomerHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IClock _clock;

    public CreateCustomerHandler(
        ILogger<CreateCustomerHandler> logger,
        ICustomerRepository customerRepository,
        IClock clock)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _clock = clock;
    }


    public async Task Handle(CreateCustomer command, CancellationToken cancellationToken = default)
    {
        _ = new Email(command.Email);

        var customer = new Customer(Guid.NewGuid(), "test@gmail.com", _clock.CurrentDate());
        await _customerRepository.AddAsync(customer);
        _logger.LogInformation($"Created a customer with ID: '{customer.Id}'.");
    }
}