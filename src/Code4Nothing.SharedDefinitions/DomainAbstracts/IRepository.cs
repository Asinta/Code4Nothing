namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public interface IRepository<TEntity> where TEntity: class
{
    IPagedCollection<TEntity> GetPagedCollection(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);
    
    IPagedCollection<TResult> GetPagedCollection<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false) where TResult : class;
    
    Task<IPagedCollection<TEntity>> GetPagedCollectionAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default);
    
    Task<IPagedCollection<TResult>> GetPagedCollectionAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default) where TResult : class;

    TEntity GetFirstOrDefault(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);
    
    TResult GetFirstOrDefault<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);
    
    Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default);
    
    Task<TResult> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default);
    
    IQueryable<TEntity> FromRawSql(string sql, params object[] parameters);

    ValueTask<TEntity> FindAsync(params object[] keyValues);
    ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken ct);
    
    IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);
    
    IQueryable<TResult> GetAll<TResult>(
        Expression<Func<TEntity,TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);
    
    Task<IList<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default);

    Task<IList<TResult>> GetAllAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken ct = default);
    
    int Count(Expression<Func<TEntity, bool>>? predicate = null);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    
    long LongCount(Expression<Func<TEntity, bool>>? predicate = null);
    Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    
    T Max<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);
    Task<T> MaxAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);
    
    T Min<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);
    Task<T> MinAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);
    
    decimal Average (Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);
    Task<decimal> AverageAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

    decimal Sum (Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);
    Task<decimal> SumAsync (Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

    bool Exists(Expression<Func<TEntity, bool>>? selector = null); 
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? selector = null);

    TEntity Create(TEntity entity);
    void Create(params TEntity[] entities);
    void Create(IEnumerable<TEntity> entities);
    
    ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity, CancellationToken ct = default);
    Task CreateAsync(params TEntity[] entities);
    Task CreateAsync(IEnumerable<TEntity> entities, CancellationToken ct = default);

    void Update(TEntity entity);
    void Update(params TEntity[] entities);
    void Update(IEnumerable<TEntity> entities);

    void Delete(object id);
    void Delete(TEntity entity);
    void Delete(params TEntity[] entities);
    void Delete(IEnumerable<TEntity> entities);
    
    void ChangeEntityState(TEntity entity, EntityState state);
}
