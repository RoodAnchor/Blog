using Blog.Data.DB;
using Blog.Data.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Blog.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _blogDbContext;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(BlogDbContext blogDbContext) =>
            _blogDbContext = blogDbContext;

        public void Dispose() { }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class 
        {
            if (_repositories == null) 
                _repositories = new Dictionary<Type, object>();

            if (hasCustomRepository)
            {
                var customRepository = _blogDbContext.GetService<IRepository<TEntity>>();

                if (customRepository != null)
                {
                    return customRepository;
                }
            }

            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
                _repositories[type] = new BaseRepository<TEntity>(_blogDbContext);

            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task SaveChanges(bool ensureAutoHistory = false)
        {
            await _blogDbContext.SaveChangesAsync();
        }
    }
}
