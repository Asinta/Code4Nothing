namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public interface IUoW : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}

public interface IUoW<TContext> : IUoW where TContext : DbContext
{
    TContext DbContext { get; }

    Task<int> SaveChangesAsync(params IUoW[] uoWs);
}
