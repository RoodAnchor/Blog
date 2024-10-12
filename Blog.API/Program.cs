using Blog.Data.DB;
using Blog.Data.Entities;
using Blog.Data.Extensions;
using Blog.Data.Repositories;
using Blog.Logic.Mapping;
using Blog.Logic.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
using Blog.API.Contracts.Validators.User;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Blog.API.Handlers;

namespace Blog.API;

public class Program
{
    private static IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.Development.json")
        .Build();

    public static void Main(string[] args)
    {
        var dbPath = Path.Combine(Path.GetFullPath(@".."), "Blog.Presentation", "bin", "Debug","net8.0", "DB", "blog.db");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
        builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlite($"Data Source={dbPath}"))
            .AddUnitOfWork()
            .AddCustomRepository<UserEntity, UserRepository>()
            .AddCustomRepository<TagEntity, TagRepository>()
            .AddCustomRepository<PostEntity, PostRepository>();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<ITagService, TagService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<ILogService, LogService>();

        builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
