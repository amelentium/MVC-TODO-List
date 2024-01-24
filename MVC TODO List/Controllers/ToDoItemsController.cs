using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_TODO_List.Contexts;
using MVC_TODO_List.Models;
using System.Diagnostics;

namespace MVC_TODO_List.Controllers
{
    public class ToDoItemsController(ToDoDBContext context, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = (await context.ToDoItems.ToListAsync())
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.CreatedAt);

            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToDoItemAddModel itemAdd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = mapper.Map<ToDoItemModel>(itemAdd);
                    await context.AddAsync(item);
                    await context.SaveChangesAsync();
                    return Ok(item);
                } 
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return Problem("Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
