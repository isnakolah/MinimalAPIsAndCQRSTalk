using Microsoft.EntityFrameworkCore;
using MinimalAPIsTalk.WithCustomMediatrLogic.Entities;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes => Set<Recipe>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        try
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}