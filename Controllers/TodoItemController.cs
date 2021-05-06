using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpGet("todoItem/task/{itemId}")]
        public TodoItem GetTask(int listId, int itemId)
        {
            return todoListService.GetTask(listId, itemId);
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

        [HttpPost("item")]
        public TodoItem CreateTodoItem(int listId, TodoItem todoItem)
        {
            return todoListService.AddTodoItem(listId, todoItem);
        }

        [HttpPost("list/list")]
        public TodoList CreateTodoList(TodoList todoList)
        {
           return todoListService.AddTodoList(todoList);
        }


        [HttpPut("task/{itemId}")]
        public TodoItem PutTodoItem(int listId, int itemId, TodoItem model)
        {
            return todoListService.UpdateTodoItem(listId, itemId, model);
        }

        [HttpPatch("todoItem/{itemId}")]
        public TodoItem ChangeTodoItemStatus(int listId, int itemId, [FromBody]JsonPatchDocument<TodoItem> model)
        {
            return todoListService.ChangeTodoItemStatus(listId, itemId, model);
        }

        [HttpDelete("{itemId}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int listId, int itemId)
        {
            TodoItem todoItem = todoListService.DeleteTodoItem(listId, itemId);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }
    }
}