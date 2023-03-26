namespace MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.Create;

public sealed class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.CreateDTO.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters");

        RuleFor(x => x.CreateDTO.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(x => x.CreateDTO.CookTimeInMinutes)
            .NotEmpty().WithMessage("Cook time is required")
            .GreaterThan((uint)0).WithMessage("Cook time must be greater than 0");

        RuleFor(x => x.CreateDTO.PrepTimeInMinutes)
            .NotEmpty().WithMessage("Prep time is required")
            .GreaterThan((uint)0).WithMessage("Prep time must be greater than 0");
    }
}
