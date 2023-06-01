using System.Text;
using Inflow.Shared.Abstractions.Exceptions;

namespace Inflow.Shared.Abstractions.Kernel.Exceptions;

public class InvalidEmailException : InflowException
{
    public InvalidEmailException(string email) : base($"Email: `{email}' is invalid")
    {
    }
}