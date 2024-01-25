using MVC_TODO_List.Enums;
using MVC_TODO_List.Models;

namespace MVC_TODO_List.Contexts.Seeds
{
    public static class ToDoItemSeeder
    {
        private static readonly ToDoItemModel[] items =
        [
            new ToDoItemModel {
                Name = "Canceled item",
                Description = "A canceled item is considered as resolved and does not have quick status change buttons",
                Status = ItemStatus.Canceled,
            },
            new ToDoItemModel
            {
                Name = "Completed item",
                Description = "A completed item is considered as resolved and does not have quick status change buttons",
                Status = ItemStatus.Completed,
            },
            new ToDoItemModel {
                Name = "Minor priority item",
                Description = "A minor priority item has a blue background and is placed below items with other priorities",
                Priority = ItemPriority.Minor,
            },
            new ToDoItemModel
            {
                Name = "Normal priority item",
                Description = "A normal priority item has a green background and is placed between items with other priorities",
                Priority = ItemPriority.Normal,
            },
            new ToDoItemModel
            {
                Name = "Major priority item",
                Description = "A major priority item has a red background and is placed above items with other priorities",
                Priority = ItemPriority.Major,
            },
            new ToDoItemModel
            {
                Name = "Old item",
                Description = "Older ones after them",
                Status = ItemStatus.InProgress,
                CreatedAt = DateTime.UtcNow - TimeSpan.FromSeconds(1000),
            },
            new ToDoItemModel
            {
                Name = "New item",
                Description = "Newer tasks go first",
                Status = ItemStatus.InProgress,
                CreatedAt = DateTime.UtcNow,
            },
        ];

        public static void SeedItems(this ToDoDBContext context)
        {
            context.ToDoItems.AddRange(items);
            context.SaveChanges();
        }
    }
}
