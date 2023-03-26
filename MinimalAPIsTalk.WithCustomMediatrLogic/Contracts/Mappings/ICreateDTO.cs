using MinimalAPIsTalk.WithCustomMediatrLogic;

namespace AutoMapper;

public interface IBaseCreateDTO : IBaseDTO
{
}

public interface ICreateDTO<out TEntity> : IBaseCreateDTO
    where TEntity : BaseEntity
{
}