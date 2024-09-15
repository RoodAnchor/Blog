namespace Blog.Logic.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Пользователь не найден") { }
}