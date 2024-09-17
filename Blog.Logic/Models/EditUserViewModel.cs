namespace Blog.Logic.Models;

public class EditUserViewModel
{
    public List<RoleModel> Roles { get; set; }
    public UserModel User { get; set; }
    public string SelectedRoleIds { get; set; }
}
