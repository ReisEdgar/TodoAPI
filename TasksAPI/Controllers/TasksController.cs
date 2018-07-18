using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;

namespace TasksAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tasks")]
    [Route("api/GG")]

    public class TasksController : Controller
    {
        private TasksDb _dbContext;

        public TasksController()
        {
            _dbContext = TasksDb.Instance;
        }

        [HttpGet]
        public IEnumerable<TodoListItemDto> Get(TodoItemStatus? status)
        {

            var item =  _dbContext.Tasks.Where(t => t.Status == status);

            if (status == null)
            {
                item = _dbContext.Tasks;
            }
 
                return item.Select(t => new TodoListItemDto
                {
                    Id = t.Id,
                    Priority = t.Priority,
                    Status = t.Status,
                    Title = t.Title,
                    Href = $"http://localhost:59115/api/Tasks/{t.Id}"
                });
            
        }

        [HttpGet("{id}")]
        public TodoItemDto Get(int id)
        {
            TodoItemDto temp = _dbContext.Tasks.Single(t => t.Id == id);

            TodoItemDto f = _dbContext.Tasks.First(t => t.Id == id);

            TodoItemDto r = (from i in _dbContext.Tasks
                            where i.Id == id
                            select  i).First();


            return f;
        }
        [HttpPost]
        public IActionResult Post([FromBody]TodoItemDto item)
        {

            if(String.IsNullOrEmpty(item.Title) || String.IsNullOrEmpty(item.Description) || item.EndDate == null)
            { 
                return BadRequest();
            }
                int max = _dbContext.Tasks.Max(t => t.Id);

            item.Id = max;

            _dbContext.Tasks.Add(item);

            return Ok(new { id = item.Id, href = $"http://localhost:59115/api/Tasks/{item.Id}" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TodoItemDto toDelete = _dbContext.Tasks.Single(t => t.Id == id);

            if(toDelete == null)
            {
                return NotFound();
            }

            _dbContext.Tasks.Remove(toDelete);

            return Ok();
        }

        [HttpPatch("{id}/{status}")]
        public IActionResult Patch(int id, TodoItemStatus status)
        {
            TodoItemDto currentItem = _dbContext.Tasks.Single(t => t.Id == id);

            if (currentItem == null)
            {
                return NotFound();
            }

            currentItem.Status = status;

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItemDto item)
        {
            TodoItemDto currentItem = _dbContext.Tasks.Single(t => t.Id == id);

            if (currentItem == null)
            {
                return NotFound();
            }
            if (item == null)
            {
                return BadRequest();
            }

            currentItem.Title = item.Title;

            return Ok();
        }
    }
}