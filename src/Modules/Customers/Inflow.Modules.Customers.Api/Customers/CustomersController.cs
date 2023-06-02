using Inflow.Modules.Customers.Core.Commands;
using Inflow.Modules.Customers.Core.DTO;
using Inflow.Modules.Customers.Core.Queries;
using Inflow.Shared.Abstractions.Commands;
using Inflow.Shared.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inflow.Modules.Customers.Api.Controllers;

[ApiController]
[Route("[controller]")]
internal class CustomersController : Controller
{
    private readonly IDispatcher _dispatcher;

    public CustomersController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }


    [HttpGet("{customerId:guid}")]
    //[Authorize]
    //[SwaggerOperation("Get customer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<CustomerDetailsDto>> GetAsync(Guid customerId)
    {
        // Customer cannot access the other customer accounts
        //customerId = _context.Identity.IsUser() ? _context.Identity.Id : customerId;
        var customer = await _dispatcher.QueryAsync(new GetCustomer { CustomerId = customerId });
        if (customer is not null)
        {
            return Ok(customer);
        }

        return NotFound();
    }


    [HttpPost]
    public async Task<ActionResult> Post(CreateCustomer command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }
}