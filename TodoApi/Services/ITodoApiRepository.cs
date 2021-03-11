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
        public Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems();
        public Task<ActionResult<TodoItem>> GetTodoItem(long id);
        public Task<bool> PutTodoItem(long id, TodoItem todoItem);
        public Task<bool> PostTodoItem(TodoItem todoItem);
        public Task<bool> DeleteTodoItem(long id);
    }
}
