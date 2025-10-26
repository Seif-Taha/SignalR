using Microsoft.EntityFrameworkCore;
using SignalR.Contexts;
using SignalR.Hubs;

namespace SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddSignalR();

            builder.Services.AddDbContext<ChatDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnection"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            #endregion

            var app = builder.Build();

            #region MiddleWares
            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("default");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapHub<ChatHub>("/chathub");

            #endregion

            app.Run();
        }
    }
}
