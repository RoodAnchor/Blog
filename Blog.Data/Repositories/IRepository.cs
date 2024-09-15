namespace Blog.Data.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    Task Create(T item);
    Task<T?> Get(int id);
    Task Update(T item);
    Task Delete(T item);
}