namespace Code4Nothing.SharedDefinitions.Extensions;

public static class UoWServiceCollectionExtensions
{
    public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddScoped<IRepositoryFactory, UoW<TContext>>();
        services.AddScoped<IUoW, UoW<TContext>>();
        services.AddScoped<IUoW<TContext>, UoW<TContext>>();

        return services;
    }
    
    public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
        where TEntity : class
        where TRepository : class, IRepository<TEntity>
    {
        services.AddScoped<IRepository<TEntity>, TRepository>();
        return services;
    }
}
