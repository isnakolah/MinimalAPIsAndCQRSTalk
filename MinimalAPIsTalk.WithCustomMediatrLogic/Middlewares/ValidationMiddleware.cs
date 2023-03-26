﻿using ValidationException = MinimalAPIsTalk.WithCustomMediatrLogic.Exceptions.ValidationException;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Middlewares;

public class ValidationMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationMiddleware(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors.Where(f => f != null))
            .ToArray();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}