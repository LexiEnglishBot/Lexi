using Microsoft.EntityFrameworkCore;
using ORM.DbEntities;

namespace ORM.DbContexts;

public sealed class LexiDbContext : DbContext
{
    public DbSet<UserDbEntity> Users { get; set; }

    public LexiDbContext(DbContextOptions<LexiDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
    }
}