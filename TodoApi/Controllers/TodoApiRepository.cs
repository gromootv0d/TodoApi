using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoApiRepository: ITodoApiRepository
    {
        private readonly TodoContext _context;
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoContext()
        {
            TodoItemsController todoItemsControllerObject = new TodoItemsController(_context);
            return await todoItemsControllerObject.GetTodoItems();
        }
    }
}
