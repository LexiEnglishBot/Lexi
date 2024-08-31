using Domain.User.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace ORM.DbContexts;

public sealed class LexiDbContext : DbContext
{
    public DbSet<UserAggregate> Users { get; set; }

    public LexiDbContext(DbContextOptions<LexiDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
    }
}