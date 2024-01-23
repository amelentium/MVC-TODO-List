using AutoMapper;
using MVC_TODO_List.Models;

namespace MVC_TODO_List.Mappers
{
    public class ToDoItemMapper : Profile
    {
        public ToDoItemMapper()
        {
            CreateMap<ToDoItemAddModel, ToDoItemModel>();
        }
    }
}
