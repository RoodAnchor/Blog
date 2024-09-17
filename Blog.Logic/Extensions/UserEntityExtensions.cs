using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Extensions;

public static class UserEntityExtensions
{
    public static void MergeChanges(this UserEntity entity, UserModel newData)
    {
        entity.FirstName = newData.FirstName!;
        entity.SecondName = newData.SecondName!;
        entity.PatronymicName = newData.PatronymicName;
        entity.About = newData.About;
        entity.Picture = newData.Picture;
    }
}
