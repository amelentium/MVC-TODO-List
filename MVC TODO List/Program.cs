using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC_TODO_List.Contexts;

namespace MVC_TODO_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<ToDoDBContext>(options =>
            {
                var connection = builder.Configuration.GetConnectionString(Constants.DBProvider);
                if (string.IsNullOrEmpty(connection))
                {
                    options.UseInMemoryDatabase(Constants.InMemoryDB);
                }
                else
                {
                    options.UseNpgsql(connection);
                }
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/ToDoItems/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ToDoItems}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
