using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface ITodoApiRepository
    {
        public Task<ActionResult<IEnumerable<TodoItem>>> GetTodoContext();
    }
}
