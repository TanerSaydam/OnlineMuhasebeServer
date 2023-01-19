using MediatR;

namespace OnlineMuhasebeServer.Application.Messaging
{
    public interface ICommand<out TResponse>:  IRequest<TResponse>
    {
    }
}
