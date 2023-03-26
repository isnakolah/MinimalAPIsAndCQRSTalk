using MinimalAPIsTalk.Introduction.Models;

namespace MinimalAPIsTalk.Introduction.Services;

public class RecipeService
{
    private static readonly IList<Recipe> _recipes = new List<Recipe>
    {
        new()
        {
            Id = 1,
            Name = "Classic Spaghetti Carbonara",
            Description =
                "A creamy and satisfying Italian pasta dish with rich, smoky bacon and a velvety egg-based sauce.",
            PrepTimeInMinutes = 15,
            CookTimeInMinutes = 20
        },
        new()
        {
            Id = 2,
            Name = "Chicken Fajitas",
            Description = "Sizzling, marinated chicken with colorful bell peppers and onions, all wrapped up in warm tortillas with your favorite toppings.",
            PrepTimeInMinutes = 20,
            CookTimeInMinutes = 15
        },
        new()
        {
            Id = 3,
            Name = "Vegetable Curry",
            Description = "A fragrant, flavorful and comforting curry with a medley of vegetables and warm spices, simmered in a rich coconut milk sauce.",
            PrepTimeInMinutes = 20,
            CookTimeInMinutes = 30
        },
        new()
        {
            Id = 4,
            Name = "Chicken Tikka Masala",
            Description = "A creamy, fragrant and flavorful Indian dish with tender chicken and a rich tomato-based sauce.",
            PrepTimeInMinutes = 20,
            CookTimeInMinutes = 30
        },
        new()
        {
            Id = 5,
            Name = "Chicken Parmesan",
            Description = "A classic Italian-American dish with tender chicken, a rich tomato sauce and a crispy, cheesy crust.",
            PrepTimeInMinutes = 20,
            CookTimeInMinutes = 30
        },
        new()
        {
            Id = 5,
            Name = "Greek Salad",
            Description = "A refreshing and crunchy salad with ripe tomatoes, crisp cucumbers, briny olives, and tangy feta cheese, all tossed in a zesty lemon-herb vinaigrette.",
            PrepTimeInMinutes = 15,
            CookTimeInMinutes = 0
        }
    };

    public IEnumerable<Recipe> Get()
    {
        return _recipes;
    }
    
    public Recipe? Get(int id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id);
    }
    
    public Recipe Add(Recipe recipe)
    {
        var newRecipe = new Recipe
        {
            Id = _recipes.Max(r => r.Id) + 1,
            Name = recipe.Name,
            Description = recipe.Description,
            PrepTimeInMinutes = recipe.PrepTimeInMinutes,
            CookTimeInMinutes = recipe.CookTimeInMinutes
        };

        _recipes.Add(newRecipe);

        return newRecipe;
    }
    
    public Recipe? Update(int id, Recipe recipe)
    {
        var existingRecipe = _recipes.FirstOrDefault(r => r.Id == id);

        if (existingRecipe is null)
        {
            return null;
        }

        existingRecipe.Name = recipe.Name;
        existingRecipe.Description = recipe.Description;
        existingRecipe.PrepTimeInMinutes = recipe.PrepTimeInMinutes;
        existingRecipe.CookTimeInMinutes = recipe.CookTimeInMinutes;

        return existingRecipe;
    }
    
    public Recipe? Delete(int id)
    {
        var existingRecipe = _recipes.FirstOrDefault(r => r.Id == id);

        if (existingRecipe is null)
        {
            return null;
        }

        _recipes.Remove(existingRecipe);

        return existingRecipe;
    }
}