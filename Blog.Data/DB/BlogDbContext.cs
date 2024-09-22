using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.DB;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Always;
    }

    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRoleEntity> UsersRoles { get; set; }
    public DbSet<PostTagEntity> PostsTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<UserRoleEntity>();

        modelBuilder.Entity<PostEntity>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<PostTagEntity>();
    }
}