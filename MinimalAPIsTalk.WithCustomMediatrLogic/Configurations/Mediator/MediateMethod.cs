namespace MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Mediator;

public static partial class Mediate
{
    private static WebApplication MediateMethod<TRequest, TResponse>(this WebApplication app, string template, string httpMethod)
        where TRequest : IRequest<TResponse>
    {
        var (name, groupName) = GetNameAndGroupName<TRequest>(template);

        app
            .MapMethods(template, new [] {httpMethod}, async ([FromServices] IMediator mediatr, [AsParameters] TRequest request) =>
            {
                var response = await mediatr.Send(request);

                return TypedResults.Ok(response);
            })
            .Produces(StatusCodes.Status200OK, typeof(TResponse))
            .Produces(StatusCodes.Status400BadRequest)
            .WithName(name)
            .WithTags(groupName);
        
        return app;
    }
    
    private static WebApplication MediateMethod<TRequest>(
        this WebApplication app, 
        string template,
        string httpMethod)
        where TRequest : IRequest
    {
        var (name, groupName) = GetNameAndGroupName<TRequest>(template);

        app
            .MapMethods(template, new [] {httpMethod}, async ([FromServices] IMediator mediatr, [AsParameters] TRequest request) =>
            {
                await mediatr.Send(request);
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName(name)
            .WithTags(groupName);
        
        return app;
    }

    private static (string Name, string GroupName) GetNameAndGroupName<T>(string template)
    {
        var name = typeof(T).Name;

        var groupName = template.Split("/").First();

        return (name, groupName);
    }
}