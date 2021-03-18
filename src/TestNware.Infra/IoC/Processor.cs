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

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand =>
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
            GetHandle(typeof(ICommandHandler<>), command.GetType())
                .Handle((dynamic)command);

        private dynamic GetHandle(Type handle, params Type[] types) =>
            _provider.GetService(handle.MakeGenericType(types));
    }
}
