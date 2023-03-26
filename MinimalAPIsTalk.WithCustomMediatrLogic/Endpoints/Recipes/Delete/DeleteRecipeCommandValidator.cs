namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.Delete;

public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
{
    public DeleteRecipeCommandValidator(IApplicationDbContext dbContext)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

        When(x => x.Id != default, () =>
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, _) =>
                {
                    var recipe = await dbContext.Recipes.FindAsync(id);

                    return recipe != null;
                }).WithMessage("Recipe with id {PropertyValue} does not exist");
        });
    }
}