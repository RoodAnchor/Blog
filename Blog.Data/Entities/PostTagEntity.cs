using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entities;

public class PostTagEntity
{
    public int Id { get; set; }

    [Column("PostId")]
    public int PostsId { get; set; }

    [Column("TagId")]
    public int TagsId { get; set; }
}