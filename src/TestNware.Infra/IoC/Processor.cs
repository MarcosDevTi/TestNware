using System;
using System.Threading.Tasks;
using TestNware.Domain.Contracts;

namespace TestNware.Infra.IoC
{
    public class Processor : IProcessor
    {
        private readonly IServiceProvider _provider;

        public Processor(IServiceProvider provider) => _provider = provider;
        public async Task<TResult> Get<TResult>(IQuery<TResult> query) => await
            GetHandle(typeof(IQueryHandler<,>), query.GetType(), typeof(TResult))
                .Handle((dynamic)query);

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            GetHandle(typeof(ICommandHandler<>), command.GetType())
                .Handle((dynamic)command);
        }


        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand =>

            
            GetHandle(typeof(ICommandHandlerAsync<>), command.GetType())
                .Handle((dynamic)command);

        private dynamic GetHandle(Type handle, params Type[] types) =>
            _provider.GetService(handle.MakeGenericType(types));
    }
}
