namespace Blog.Logic.Exceptions;

public class RoleNotFoundException : Exception
{
    public RoleNotFoundException() : base("Роль не найдена в БД") { }
}
