using MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.DTOs;

/// <summary>
/// Data Transfer Object for <see cref="Recipe"/> for POST requests.
/// </summary>
public sealed record RecipeCreateDTO : ICreateDTO<Recipe>
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required uint PrepTimeInMinutes { get; init; }
    public required uint CookTimeInMinutes { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RecipeCreateDTO, Recipe>();
    }
}