using System.Threading.Tasks;

namespace TestNware.Domain.Contracts
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
