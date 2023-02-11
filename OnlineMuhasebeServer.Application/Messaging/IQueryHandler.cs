using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : 
        IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
