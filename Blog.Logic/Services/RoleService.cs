using AutoMapper;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.UoW;
using Blog.Logic.Models;
using Blog.Logic.Extensions;
using Blog.Logic.Exceptions;

namespace Blog.Logic.Services;

public class RoleService : IRoleService
{
    private readonly IRepository<RoleEntity> _repo;
    private readonly IMapper _mapper;

    public RoleService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repo = unitOfWork.GetRepository<RoleEntity>(false);
        _mapper = mapper;
    }

    public async Task CreateRole(RoleModel role)
    {
        var entity = _mapper.Map<RoleEntity>(role);

        await _repo.Create(entity);
    }

    public async Task DeleteRole(RoleModel role)
    {
        var entity = await _repo.Get(role.Id);

        if (entity == null) throw new RoleNotFoundException();

        await _repo.Delete(entity);
    }

    public async Task<RoleModel> GetRole(int id)
    {
        var entity = await _repo.Get(id);

        if (entity == null) throw new RoleNotFoundException();

        var role = _mapper.Map<RoleModel>(entity);

        return role;
    }

    public List<RoleModel> GetRoles()
    {
        var entities = _repo.GetAll();
        var roles = _mapper.Map<List<RoleModel>>(entities);

        return roles;
    }

    public async Task UpdateRole(RoleModel role)
    {
        var entity = await _repo.Get(role.Id);

        if (entity == null) throw new RoleNotFoundException();

        entity.MergeChanges(role);

        await _repo.Update(entity);
    }
}
