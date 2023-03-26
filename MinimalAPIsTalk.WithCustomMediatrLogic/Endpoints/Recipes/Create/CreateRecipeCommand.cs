using MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.DTOs;
using MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.Create;

[HttpPost("/recipes")]
public sealed record CreateRecipeCommand([FromBody] RecipeCreateDTO CreateDTO) : ICreateRequest<RecipeGetDTO>;

public sealed class CreateRecipeCommandHandler : ICreateRequestHandler<CreateRecipeCommand, RecipeGetDTO>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateRecipeCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<RecipeGetDTO> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _mapper.Map<Recipe>(request.CreateDTO);

        _dbContext.Recipes.Add(recipe);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<RecipeGetDTO>(recipe);
    }
}