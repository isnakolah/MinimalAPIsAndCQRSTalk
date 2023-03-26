namespace MediatR;



public interface IReadRequest<out TResponse> : IRequest<TResponse>
{
}

public interface IReadRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IReadRequest<TResponse>
{
}