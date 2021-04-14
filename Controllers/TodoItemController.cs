using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//using Controller.Models;

namespace TodoItems.Controllers
{

    [Route("api/todolists/{listId}/tasks")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        private TodoListService todoListService;


        public TodoItemController(TodoListService service1)
        {
            this.todoListService = service1;
        }

        [HttpGet("getall")]
        public ActionResult<List<TodoItem>> GetTodoItems(int listId)
        {
            return Ok(todoListService.GetAllTodoItems(listId));
        }

        [HttpGet("dashboard")]
        public ActionResult<List<TodoItem>> GetTodoItemsForToday()
        {
            return Ok(todoListService.GetTodayTasks());
        }

        [HttpGet("collection/today")]
        public ActionResult<TodoItem> GetTodoItemById()
        {
            return Ok(todoListService.GetTaskDTO());
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAllTasks(bool allStatus)
        {
            return todoListService.GetAllTask(allStatus);
        }

        [HttpPost("createitem")]
        public void CreateTodoItem(int listId, TodoItem todoItem)
        {

            todoListService.AddTodoItem(listId, todoItem);
        }

        [HttpPost("createlist")]
        public void CreateTodoList(TodoList todoList)
        {
            todoListService.AddTodoList(todoList);
        }


        [HttpPut("update/{itemId}")]
        public IActionResult PutTodoItem(int listId, int itemId, TodoItem model)
        {
            return Ok(todoListService.UpdateTodoItem(listId, itemId, model));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int listId, int itemId)
        {
            return Ok(todoListService.DeleteTodoItem(listId, itemId));
        }
    }


}