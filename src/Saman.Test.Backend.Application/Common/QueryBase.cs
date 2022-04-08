using MediatR;

namespace Saman.Test.Backend.Application.Common
{
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {
    }
}
