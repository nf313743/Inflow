using System;
using Inflow.Shared.Abstractions.Exceptions;

namespace Inflow.Modules.Customers.Core.Exceptions;

internal class CustomerNotActiveException : InflowException
{
    public Guid CustomerId { get; }

    public CustomerNotActiveException(Guid customerId) : base($"Customer with ID: '{customerId}' is not active.")
    {
        CustomerId = customerId;
    }

    protected CustomerNotActiveException(string message) : base(message)
    {
    }
}