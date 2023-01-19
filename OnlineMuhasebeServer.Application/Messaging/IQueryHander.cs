using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    public interface IQueryHander<in TQuery, TResponse> : 
        IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
