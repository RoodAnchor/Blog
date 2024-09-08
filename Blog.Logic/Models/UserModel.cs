namespace Blog.Logic.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? PatronymicName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string About { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public List<RoleModel> Roles { get; set; } = [];
    }
}
