using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//using Controller.Models;

namespace TodoItems.Controllers
{

    [Route("api/todolist")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService todoItemService;
        private TodoListService todoListService;


        public TodoItemController(TodoItemService service, TodoListService service1)
        {
            this.todoItemService = service;
            this.todoListService = service1;
        }

        [HttpGet("/getAll")]
        public ActionResult<List<TodoItem>> GetTodoItems()
        {
            return todoListService.ReadAllTodoItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            TodoItem createdItem = todoListService.AddTodoItem(todoItem);

            return Created($"api/todolist/tasks/{createdItem.Id}", createdItem);
            //return todoListService.AddTodoItem(todoItem);
        }
        

        [HttpPut("/{listId}/tasks")]
        public IActionResult PutTodoItem(TodoItem model)
        {
            return Ok(todoListService.UpdateTodoItem(model));
        }

        [HttpDelete("/delete/{id}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int id)
        {
            return Ok(todoListService.DeleteTodoItem(id));
        }
    }


}