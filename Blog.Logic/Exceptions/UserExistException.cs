namespace Blog.Logic.Exceptions
{
    public class UserExistException : Exception
    {
        public UserExistException() : base("Пользователь уже зарегестрирован") { }
    }
}
