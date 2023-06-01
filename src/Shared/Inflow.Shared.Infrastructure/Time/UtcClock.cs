using Inflow.Shared.Abstractions.Time;

namespace Inflow.Shared.Infrastructure.Time;

public sealed class UtcClock : IClock
{

    public DateTime CurrentDate() => DateTime.UtcNow;
}