namespace MinimalAPIsTalk.WithCustomMediatrLogic;

public abstract record BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
}