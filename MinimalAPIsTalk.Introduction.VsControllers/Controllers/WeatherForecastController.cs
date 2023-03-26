using Microsoft.AspNetCore.Mvc;
using MinimalAPIsTalk.Introduction.VsControllers.Models;
using MinimalAPIsTalk.Introduction.VsControllers.Services;

namespace MinimalAPIsTalk.Introduction.VsControllers.Controllers;

[ApiController]
[Route("with-controller/recipes/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly RecipeService _recipeService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, RecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<IEnumerable<Recipe>> Get()
    {
        var recipes = _recipeService.Get();

        return Ok(recipes);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<Recipe> Get([FromRoute] int id)
    {
        var recipe = _recipeService.Get(id);

        if (recipe is null)
        {
            return NotFound();
        }

        return Ok(recipe);
    }
    
    [HttpPost]
    public ActionResult<Recipe> Add([FromBody] Recipe recipe)
    {
        var newRecipe = _recipeService.Add(recipe);

        return CreatedAtRoute("GetRecipe", new { id = newRecipe.Id }, newRecipe);
    }
    
    [HttpPut("{id:int}")]
    public ActionResult<Recipe> Update([FromRoute] int id, [FromBody] Recipe recipe)
    {
        var updatedRecipe = _recipeService.Update(id, recipe);

        if (updatedRecipe is null)
        {
            return NotFound();
        }

        return Ok(updatedRecipe);
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult<Recipe> Delete([FromRoute] int id)
    {
        var deletedRecipe = _recipeService.Delete(id);

        if (deletedRecipe is null)
        {
            return NotFound();
        }

        return Ok(deletedRecipe);
    }
}