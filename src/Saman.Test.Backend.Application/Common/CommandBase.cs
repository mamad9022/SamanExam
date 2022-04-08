using MediatR;

namespace Saman.Test.Backend.Application.Common
{
    public class CommandBase<TResult> : IRequest<TResult> where TResult : class
    {
    }
}
