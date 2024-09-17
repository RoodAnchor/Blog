using Blog.Logic.Models;

namespace Blog.Logic.Services;

public interface IUserService
{
    public Task<UserModel?> RegisterUser(UserModel user);
    public Task<UserModel?> AuthenticateUser(SignInViewModel credentials);
    public Task<UserModel?> GetUser(int id);
    public Task<UserModel?> GetUser(string email);
    public Task<List<UserModel>> GetAllUsers();
    public Task UpdateUser(UserModel user);
    public Task DeleteUser(int id);
}