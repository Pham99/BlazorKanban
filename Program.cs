using KanbanApp.Components;
using KanbanApp.Data;
using KanbanApp.Services;
using Microsoft.EntityFrameworkCore;

namespace KanbanApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Blazor Bootstrap
            builder.Services.AddBlazorBootstrap();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //p?id�v�m slu�by jako user atd...
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<KanbanCardService>();
            builder.Services.AddSingleton<KanbanColumnService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
