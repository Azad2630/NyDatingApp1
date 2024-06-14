using NyDatingApp1.Components;
using NyDatingApp1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NyDatingApp1.Data;
using Microsoft.AspNetCore.Identity;


namespace NyDatingApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<datingdatabase>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("datingdatabase") ?? throw new InvalidOperationException("Connection string 'datingdatabase' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<LikeService>();

            builder.Services.AddScoped<ProfileService>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

           
            app.MapRazorPages();

            app.Run();
        }
    }
}
