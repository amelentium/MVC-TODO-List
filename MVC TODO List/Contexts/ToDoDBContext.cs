using Microsoft.EntityFrameworkCore;
using MVC_TODO_List.Contexts.Configurations;
using MVC_TODO_List.Models;

namespace MVC_TODO_List.Contexts
{
    public class ToDoDBContext(DbContextOptions options) : DbContext(options)
    {
        //public DbSet<UserModel> Users { get; set; }
        public DbSet<ToDoItemModel> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ToDoItemModel>(new ToDoItemConfiguration());
        }
    }
}
