namespace MediatR;

public interface IUpdateRequest : IRequest
{
}

public interface IUpdateRequestHandler<in TRequest> : IRequestHandler<TRequest>
    where TRequest : IUpdateRequest
{
}