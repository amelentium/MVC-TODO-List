using MVC_TODO_List.Enums;

namespace MVC_TODO_List
{
    public static class Constants
    {
        public const string DBProvider = "PostgreSQL";
        public const string InMemoryDB = "PostgreSQL";
        public static Dictionary<ItemStatus, string> ItemStatuses = new()
        {
            { ItemStatus.Canceled, "Canceled" },
            { ItemStatus.Planned, "Planned" },
            { ItemStatus.InProgress, "In Progress" },
            { ItemStatus.Completed, "Completed" },
        };
    }
}
