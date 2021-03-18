using System.Threading.Tasks;

namespace TestNware.Domain.Contracts
{
    public interface IProcessor
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> Get<TResult>(IQuery<TResult> query);
    }
}
