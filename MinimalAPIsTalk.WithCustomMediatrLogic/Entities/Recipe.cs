namespace MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

public sealed record Recipe : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public uint PrepTimeInMinutes { get; set; }
    public uint CookTimeInMinutes { get; set; }
}