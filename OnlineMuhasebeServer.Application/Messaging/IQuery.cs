using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
