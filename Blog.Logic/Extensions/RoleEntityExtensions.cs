using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Extensions;

public static class RoleEntityExtensions
{
    public static void MergeChanges(this RoleEntity entity, RoleModel model)
    {
        entity.Name = model.Name;
        entity.Description = model.Description;
    }
}
