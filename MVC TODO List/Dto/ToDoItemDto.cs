using MVC_TODO_List.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_TODO_List.Models
{
    public class ToDoItemDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public ItemPriority Priority { get; set; } = ItemPriority.Normal;

        [Required]
        public ItemStatus Status { get; set; } = ItemStatus.Planned;
    }
}
