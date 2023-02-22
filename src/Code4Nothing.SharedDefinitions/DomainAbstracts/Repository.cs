namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(DbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = DbContext.Set<TEntity>();
    }

    public IPagedCollection<TEntity> GetPagedCollection(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0, int pageSize = 20, bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public IPagedCollection<TResult> GetPagedCollection<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class
    {
        throw new NotImplementedException();
    }

    public Task<IPagedCollection<TEntity>> GetPagedCollectionAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0, int pageSize = 20, bool disableTracking = true, bool ignoreQueryFilters = false,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPagedCollection<TResult>> GetPagedCollectionAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true,
        bool ignoreQueryFilters = false, CancellationToken ct = default) where TResult : class
    {
        throw new NotImplementedException();
    }

    public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> FromRawSql(string sql, params object[] parameters)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TEntity> FindAsync(params object[] keyValues)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public int Count(Expression<Func<TEntity, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public long LongCount(Expression<Func<TEntity, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public T Max<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public Task<T> MaxAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public T Min<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public Task<T> MinAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public decimal Average(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> AverageAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public decimal Sum(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> SumAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<TEntity, bool>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? selector = null)
    {
        throw new NotImplementedException();
    }

    public TEntity Create(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Create(params TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public void Create(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(params TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(IEnumerable<TEntity> entities, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(params TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public void Update(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(object id)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(params TEntity[] entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public void ChangeEntityState(TEntity entity, EntityState state)
    {
        throw new NotImplementedException();
    }
}
