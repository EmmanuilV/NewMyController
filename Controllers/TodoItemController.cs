using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

//using Controller.Models;

namespace TodoItems.Controllers
{

    [Route("api/tasks")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoListService todoListService;


        public TodoItemController(TodoListService service1)
        {
            this.todoListService = service1;
        }

        [HttpGet("lists")]
        public List<TodoList> GetTodoLists()
        {
            return todoListService.GetAllTodoLists();
        }

        [HttpGet("{listId}/all")]
        public List<TodoItem> GetTodoItems(int listId)
        {
            return todoListService.GetAllTodoItems(listId);
        }


        [HttpGet("{listId}/todoItem/task/{itemId}")]
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
            return todoListService.GetAllTasks(allStatus);
        }

        [HttpPost("{listId}/item")]
        public TodoItem CreateTodoItem(int listId, TodoItem todoItem)
        {
            return todoListService.AddTodoItem(listId, todoItem);
        }

        [HttpPost("list/list")]
        public TodoList CreateTodoList(TodoList todoList)
        {
           return todoListService.AddTodoList(todoList);
        }


        [HttpPut("{listId}/task/{itemId}")]
        public TodoItem PutTodoItem(int listId, int itemId, TodoItem model)
        {
            return todoListService.UpdateTodoItem(listId, itemId, model);
        }

        [HttpPatch("{listId}/todoItem/{itemId}")]
        public TodoItem ChangeTodoItemStatus(int listId, int itemId, [FromBody]JsonPatchDocument<TodoItem> model)
        {
            return todoListService.ChangeTodoItemStatus(listId, itemId, model);
        }

        [HttpDelete("{listId}/{itemId}")]
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