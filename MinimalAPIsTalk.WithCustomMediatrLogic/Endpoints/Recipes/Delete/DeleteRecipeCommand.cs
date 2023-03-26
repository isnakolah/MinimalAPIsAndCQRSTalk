namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.Delete;

[HttpDelete("/recipes/{id:guid}")]
public sealed record DeleteRecipeCommand([FromRoute] Guid Id) : IDeleteRequest;

public sealed class DeleteRecipeCommandHandler : IDeleteRequestHandler<DeleteRecipeCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteRecipeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _dbContext.Recipes.FindAsync(request.Id);

        _dbContext.Recipes.Remove(recipe!);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
} 