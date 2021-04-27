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

        [HttpGet("all")]
        public List<TodoItem> GetTodoItems(int listId)
        {
            return todoListService.GetAllTodoItems(listId);
        }

        [HttpGet("{itemId}")]
        public List<TodoItem> GetTask(int listId, int itemId)
        {
            return todoListService.GetAllTodoItems(listId);
        }

        [HttpGet("dashboard")]
        public PlannedDTO GetTodoItemsForToday()
        {
            return todoListService.GetTodayTasks();
        }

        [HttpGet("collection/today")]
        public List<NotDoneDTO> GetTodoItemById()
        {
            return todoListService.GetTaskDTO();
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAllTasks(bool allStatus)
        {
            return todoListService.GetAllTask(allStatus);
        }

        [HttpPost("item/create")]
        public TodoItem CreateTodoItem(int listId, TodoItem todoItem)
        {
            return todoListService.AddTodoItem(listId, todoItem);
        }

        [HttpPost("list/create")]
        public TodoList CreateTodoList(TodoList todoList)
        {
           return todoListService.AddTodoList(todoList);
        }


        [HttpPut("update/{itemId}")]
        public TodoItem PutTodoItem(int listId, int itemId, TodoItem model)
        {
            return todoListService.UpdateTodoItem(listId, itemId, model);
        }

        [HttpDelete("delete/{itemId}")]
        public TodoItem DeleteTodoItemById(int listId, int itemId)
        {
            return todoListService.DeleteTodoItem(listId, itemId);
        }
    }
}