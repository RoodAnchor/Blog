namespace Blog.API.Contracts.Models.User;

public class CreateUserRequest
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? PatronymicName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string About { get; set; }
    public DateTime? BirthDate { get; set; }
}
