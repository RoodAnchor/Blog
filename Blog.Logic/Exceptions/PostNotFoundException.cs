namespace Blog.Logic.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException() : base("Статья не найдена в БД") { }
    }
}
