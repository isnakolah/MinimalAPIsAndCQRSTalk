using Microsoft.AspNetCore.Mvc;
using MinimalAPIsTalk.Introduction.VsControllers.Models;
using MinimalAPIsTalk.Introduction.VsControllers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<RecipeService>();

var app = builder.Build();

app.MapGet("/with-minimal-apis/recipes", ([FromServices] RecipeService recipeService) =>
{
    var recipes = recipeService.Get();

    return Results.Ok(recipes);
});

app.MapGet("/with-minimal-apis/recipes/{id:int}", ([FromServices] RecipeService recipeService, [FromRoute] int id) =>
{
    var recipe = recipeService.Get(id);

    if (recipe is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(recipe);
});

app.MapPost("/with-minimal-apis/recipes", ([FromServices] RecipeService recipeService, [FromBody] Recipe recipe) =>
{
    var newRecipe = recipeService.Add(recipe);

    return Results.Created($"/with-minimal-apis/recipes/{newRecipe.Id}", newRecipe);
});

app.MapPut("/with-minimal-apis/recipes/{id:int}", ([FromServices] RecipeService recipeService, [FromRoute] int id, [FromBody] Recipe recipe) =>
{
    var updatedRecipe = recipeService.Update(id, recipe);

    if (updatedRecipe is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(updatedRecipe);
});

app.MapDelete("/with-minimal-apis/recipes/{id:int}", ([FromServices] RecipeService recipeService, [FromRoute] int id) =>
{
    var deletedRecipe = recipeService.Delete(id);

    if (deletedRecipe is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(deletedRecipe);
});

app.MapControllers();

app.Run();