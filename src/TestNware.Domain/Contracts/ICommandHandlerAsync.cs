using System.Threading.Tasks;

namespace TestNware.Domain.Contracts
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
