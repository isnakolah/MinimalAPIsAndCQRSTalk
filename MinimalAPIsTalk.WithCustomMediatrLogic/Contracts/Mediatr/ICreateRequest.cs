namespace MediatR;

public interface ICreateRequest<out TResponse> : IRequest<TResponse>
    where TResponse : IBaseReadDTO
{
}

public interface ICreateRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TResponse : IBaseReadDTO
    where TRequest : ICreateRequest<TResponse>
{
}