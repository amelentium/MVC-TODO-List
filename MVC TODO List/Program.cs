using Microsoft.EntityFrameworkCore;
using MVC_TODO_List.Contexts;
using MVC_TODO_List.Contexts.Seeds;

namespace MVC_TODO_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var isInMemory = false;

            builder.Services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<ToDoDBContext>(options =>
            {
                var connection = builder.Configuration.GetConnectionString(Constants.DBProvider);
                if (string.IsNullOrEmpty(connection))
                {
                    options.UseInMemoryDatabase(Constants.InMemoryDB);
                    isInMemory = true;
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

            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ToDoDBContext>())
            {
                if (!isInMemory && context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.ToDoItems.Any()) {
                    context.SeedItems();
                }
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
