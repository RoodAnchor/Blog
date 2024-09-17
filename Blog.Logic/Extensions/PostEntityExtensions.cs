using Blog.Data.Entities;
using Blog.Logic.Models;

namespace Blog.Logic.Extensions;

public static class PostEntityExtensions
{
    public static void MergeChanges(this PostEntity entity, PostModel newData)
    {
        entity.Title = newData.Title;
        entity.Description = newData.Description;
        entity.Content = newData.Content;
        entity.Views = newData.Views;
    }
}