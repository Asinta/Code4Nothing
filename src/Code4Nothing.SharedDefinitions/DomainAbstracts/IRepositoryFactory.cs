namespace Code4Nothing.SharedDefinitions.DomainAbstracts;

public interface IRepositoryFactory
{
    IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
}
