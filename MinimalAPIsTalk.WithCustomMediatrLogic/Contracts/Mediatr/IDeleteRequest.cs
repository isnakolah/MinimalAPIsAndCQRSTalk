namespace MediatR;

public interface IDeleteRequest : IRequest
{
}

public interface IDeleteRequestHandler<in TRequest> : IRequestHandler<TRequest>
    where TRequest : IDeleteRequest
{
}