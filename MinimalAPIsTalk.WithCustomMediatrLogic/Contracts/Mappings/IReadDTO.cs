using MinimalAPIsTalk.WithCustomMediatrLogic;

namespace AutoMapper;

public interface IBaseReadDTO : IBaseDTO
{
    public string Id { get; init; }
}

public interface IReadDTO<in TEntity> : IBaseReadDTO
    where TEntity : BaseEntity
{
}
