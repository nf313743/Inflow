namespace Inflow.Shared.Abstractions.Commands;

public interface ICommandDispatcher
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}