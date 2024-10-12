using Blog.API.Contracts.Models.Role;

namespace Blog.API.Contracts.Models.User;

public class GetUserResponse
{
    private string _picture;

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? PatronymicName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string About { get; set; }
    public string Picture
    {
        get => string.IsNullOrEmpty(_picture) ? "https://thispersondoesnotexist.com/" : _picture;
        set => _picture = value;
    }
    public DateTime? BirthDate { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    public List<GetRoleResponse> Roles { get; set; } = [];
}
