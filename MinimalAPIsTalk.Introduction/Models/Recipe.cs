namespace MinimalAPIsTalk.Introduction.Models;

public sealed record Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PrepTimeInMinutes { get; set; }
    public int CookTimeInMinutes { get; set; }
}