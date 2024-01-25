using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_TODO_List.Enums;
using MVC_TODO_List.Models;

namespace MVC_TODO_List.Contexts.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItemModel>
    {
        public void Configure(EntityTypeBuilder<ToDoItemModel> builder)
        {
            builder
                .Property(x => x.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<ItemStatus>(v));

            builder
                .Property(x => x.Priority)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<ItemPriority>(v));

            builder
                .Property(x => x.CreatedAt)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                )
                .HasDefaultValueSql("now()::timestamp");
        }
    }
}
