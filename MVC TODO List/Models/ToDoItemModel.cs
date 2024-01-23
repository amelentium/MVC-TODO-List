using MVC_TODO_List.Enums;

namespace MVC_TODO_List.Models
{
    public class ToDoItemModel
    {
        public Guid Id { get; init; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ItemPriority Priority { get; set; }

        public ItemStatus Status { get; set; }

        public DateTime CreatedAt { get; init; }
    }
}
