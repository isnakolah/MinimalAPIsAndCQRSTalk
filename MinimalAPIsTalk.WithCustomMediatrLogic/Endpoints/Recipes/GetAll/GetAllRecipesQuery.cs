using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.DTOs;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.GetAll;

[HttpGet("/recipes")]
public sealed record GetAllRecipesQuery : IReadRequest<IEnumerable<RecipeGetDTO>>;

public sealed class GetAllRecipesQueryHandler : IReadRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeGetDTO>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IConfigurationProvider _mapperConfig;

    public GetAllRecipesQueryHandler(IApplicationDbContext dbContext, IConfigurationProvider mapperConfig)
    {
        _dbContext = dbContext;
        _mapperConfig = mapperConfig;
    }

    public async Task<IEnumerable<RecipeGetDTO>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _dbContext.Recipes
            .ProjectTo<RecipeGetDTO>(_mapperConfig)
            .ToArrayAsync(cancellationToken);

        return recipes;
    }
} 
