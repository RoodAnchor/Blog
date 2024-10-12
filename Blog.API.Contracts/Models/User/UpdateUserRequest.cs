namespace Blog.API.Contracts.Models.User;
public class UpdateUserRequest
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? PatronymicName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string About { get; set; }
    public string Picture { get; set; }
    public int[] RoleIds { get; set; } = [];
}
