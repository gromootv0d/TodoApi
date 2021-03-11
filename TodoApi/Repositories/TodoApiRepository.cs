using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Repositories
{
    public class TodoApiRepository : ITodoApiRepository
    {
        private readonly TodoContext _context;

        public TodoApiRepository(TodoContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<bool> PutTodoItem(long id,TodoItem todoItem)
        {
            try
            {
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    //return NotFound();
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                //return NotFound();
                return false;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;
            //return NoContent();
        }

        bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
