using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services
{
    public interface ITodoApiRepository
    {
        public Task<ActionResult<IEnumerable<TodoItem>>> GetTodoContext();
    }
}
