namespace Code4Nothing.Blogs.Infrastructure.EntityFrameworkCore;

public class Code4NothingBlogsDbContext : DbContext
{
    private readonly IMediator _mediator;

    public Code4NothingBlogsDbContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotImplementedException("Please don't call SaveChanges(), use SaveChangesAsync() instead");
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var posts = ChangeTracker.Entries().Where(e => e is { Entity: Post, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in posts)
        {
            ((Post)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((Post)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
        
        var domainEntities = ChangeTracker.Entries<IDomainEvent>().Where(e => e.Entity.GetDomainEvents().Any());
        var domainEvents = domainEntities.SelectMany(e => e.Entity.GetDomainEvents()).ToList();

        (domainEntities as EntityEntry<IDomainEvent>[] ?? domainEntities).ToList().ForEach(e => e.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(Enum.GetName(DatabaseSchema.Blogs));
    }
}
