namespace Blog.Logic.Exceptions;

public class CommentNotFoundException : Exception
{
    public CommentNotFoundException() : base("Комментарий не найден в БД") { }
}
