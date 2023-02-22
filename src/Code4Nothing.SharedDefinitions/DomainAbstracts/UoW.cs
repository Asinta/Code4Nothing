namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public class UoW<TContext> : IRepositoryFactory, IUoW<TContext> where TContext: DbContext
{
    private bool _disposed = false;
    private Dictionary<Type, object>? _repositories;

    public TContext DbContext { get; }

    public UoW(TContext context) => DbContext = context ?? throw new ArgumentNullException(nameof(context));


    IRepository<TEntity> IUoW.GetRepository<TEntity>(bool hasCustomRepository)
    {
        _repositories ??= new Dictionary<Type, object>();

        if (hasCustomRepository)
        {
            var customRepository = DbContext.GetService<IRepository<TEntity>>();
            return customRepository;
        }

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<TEntity>(DbContext);
        }

        return (IRepository<TEntity>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default) => await DbContext.SaveChangesAsync(ct);

    IRepository<TEntity> IRepositoryFactory.GetRepository<TEntity>(bool hasCustomRepository)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) _repositories?.Clear();
            
            DbContext.Dispose();
        }

        _disposed = true;
    }

    public async Task<int> SaveChangesAsync(params IUoW[] uoWs)
    {
        using var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        
        var count = 0;
        foreach (var uow in uoWs)
        {
            count += await uow.SaveChangesAsync().ConfigureAwait(false);
        }

        count += await SaveChangesAsync();

        ts.Complete();

        return count;
    }
}
