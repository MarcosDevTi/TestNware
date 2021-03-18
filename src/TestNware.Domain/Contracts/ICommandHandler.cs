using System.Threading.Tasks;

namespace TestNware.Domain.Contracts
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
