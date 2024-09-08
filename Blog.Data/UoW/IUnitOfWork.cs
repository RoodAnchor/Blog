using Blog.Data.Repositories;

namespace Blog.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        public Task SaveChanges(bool ensureAutoHistory = false);

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class;
    }
}
