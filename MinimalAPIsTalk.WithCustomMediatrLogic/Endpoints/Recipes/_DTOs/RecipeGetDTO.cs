using MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.DTOs;

/// <summary>
/// Data Transfer Object for <see cref="Recipe"/> for GET requests.
/// </summary>
public sealed record RecipeGetDTO : IReadDTO<Recipe>
{
    public string Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public uint PrepTimeInMinutes { get; init; }
    public uint CookTimeInMinutes { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Recipe, RecipeGetDTO>();
    }
}