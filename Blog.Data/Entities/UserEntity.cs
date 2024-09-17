namespace Blog.Data.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string? PatronymicName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? About { get; set; }
    public string? Picture { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegisterDate { get; set; }
    public List<RoleEntity> Roles { get; set; } = [];
    public List<CommentEntity> Comments { get; set; } = [];
    public List<PostEntity> Posts { get; set; } = [];
}