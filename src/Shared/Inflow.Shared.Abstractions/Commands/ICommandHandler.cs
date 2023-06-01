namespace Inflow.Shared.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken = default);
}