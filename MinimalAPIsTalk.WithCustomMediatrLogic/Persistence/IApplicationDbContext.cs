using Microsoft.EntityFrameworkCore;
using MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Persistence;

public interface IApplicationDbContext
{
    DbSet<Recipe> Recipes { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}