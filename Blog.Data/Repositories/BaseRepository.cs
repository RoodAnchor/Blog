using Blog.Data.DB;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _dbContext;

        public DbSet<T> Set { get; set; }

        public BaseRepository(BlogDbContext dbContext) 
        {
            _dbContext = dbContext;

            var set = _dbContext.Set<T>();

            set.Load();

            Set = set;
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public async Task Create(T item) 
        {
            await Set.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Set.FindAsync(id);
        }

        public async Task Update(T item)
        {
            Set.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            Set.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
