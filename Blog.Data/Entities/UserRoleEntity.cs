using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities;

public class UserRoleEntity
{
    public int Id { get; set; }

    [Column("UserId")]
    public int UsersId { get; set; }

    [Column("RoleId")]
    public int RolesId { get; set; }
}
