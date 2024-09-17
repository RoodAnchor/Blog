using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;
using Blog.Logic.Exceptions;
using Blog.Logic.Extensions;

namespace Blog.Logic.Services;
public class UserService : IUserService
{
    private readonly UserRepository? _userRepo;
    private readonly IRepository<RoleEntity> _roleRepo;
    private readonly IMapper _mapper;

    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepo = unitOfWork.GetRepository<UserEntity>() as UserRepository;
        _roleRepo = unitOfWork.GetRepository<RoleEntity>(false);
        _mapper = mapper;
    }

    public async Task<UserModel?> RegisterUser(UserModel newUser)
    {
        var existingUser = await GetUser(newUser.Email!);
        if (existingUser != null) throw new UserExistException();

        var entity = _mapper.Map<UserEntity>(newUser);
        var defaultRole = await _roleRepo.Get(3);

        if (defaultRole != null)
            entity.Roles.Add(defaultRole);

        await _userRepo!.Create(entity);

        return await GetUser(newUser.Email!);
    }

    public async Task<UserModel?> AuthenticateUser(SignInViewModel credentials)
    {
        var user = await GetUser(credentials.Email);

        if (user == null) return null;
        if (user.Password != credentials.Password) return null;

        return user;
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var entity = await _userRepo!.Get(id);

        if (entity == null) throw new UserNotFoundException();

        var user = _mapper.Map<UserModel>(entity);

        return user;
    }

    public async Task<UserModel?> GetUser(string email)
    {
        var entity = await _userRepo!.Get(email);
        var user = _mapper.Map<UserModel>(entity);

        return user;
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        var entities = await _userRepo!.GetAll();
        var users = _mapper.Map<List<UserModel>>(entities);

        return users;
    }

    public async Task UpdateUser(UserModel updatedUser)
    {
        var entity = await _userRepo!.Get(updatedUser.Id);

        if (entity == null) return;

        entity.MergeChanges(updatedUser);

        entity.Roles.Clear();

        foreach (var role in updatedUser.Roles)
        {
            var roleEntity = await _roleRepo.Get(role.Id);

            if(roleEntity != null)
                entity.Roles.Add(roleEntity);
        }

        await _userRepo.Update(entity);
    }

    public async Task DeleteUser(int id)
    {
        var entity = await _userRepo!.Get(id);

        if (entity != null)
            await _userRepo.Delete(entity);
    }
}