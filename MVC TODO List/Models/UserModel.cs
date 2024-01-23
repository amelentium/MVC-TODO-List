using System.ComponentModel.DataAnnotations;

namespace MVC_TODO_List.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Login { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        public List<ToDoItemModel>? ToDoItems { get; set; }
    }
}
