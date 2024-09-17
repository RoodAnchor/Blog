using Blog.Data.DB;
using Blog.Data.Entities;
using Blog.Data.Extensions;
using Blog.Data.Repositories;
using Blog.Logic.Mapping;
using Blog.Logic.Services;
using Blog.Presentation.Authorization.Handlers;
using Blog.Presentation.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace Blog.Presentation
{
    public class Program
    {
        private static IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            builder.Services.AddDbContext<BlogDbContext>()
                .AddUnitOfWork()
                .AddCustomRepository<UserEntity, UserRepository>()
                .AddCustomRepository<TagEntity, TagRepository>()
                .AddCustomRepository<PostEntity, PostRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.AddScoped<IAuthorizationHandler, OwnerOnlyHandler>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };

                    options.AccessDeniedPath = "/Errors/AccessDenied";
                });

            builder.Services.AddAuthorization(options => 
            {
                options.AddPolicy("OwnerOnly", policy => policy.AddRequirements(new OwnerOnlyRequirement(true)));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Errors");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(async context => 
            {
                if (context.HttpContext.Response.StatusCode == 404)
                    context.HttpContext.Response.Redirect("/Errors/ResourceNotFound");

                if (context.HttpContext.Response.StatusCode == 401)
                    context.HttpContext.Response.Redirect("/Errors/AccessDenied");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}