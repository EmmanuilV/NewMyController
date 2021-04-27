using System;
using TodoItems.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoItems
{
    public class TodoListService
    {

        private TodoListContext db;

        public TodoListService(TodoListContext context)
        {
            this.db = context;
        }
        public TodoItem AddTodoItem(int listId, TodoItem todoItem)
        {
            todoItem.TodoListId = listId;
            db.TodoItems.Add(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public TodoItem DeleteTodoItem(int listId, int itemId)
        {
            var todoItem = db.TodoItems
            .Where(b => b.TodoListId == listId && b.TodoItemId == itemId)
            .Single();
            db.TodoItems.Remove(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public List<TodoItem> GetAllTodoItems(int listId)
        {
            List<TodoItem> TodoItems = new List<TodoItem>();
            TodoItems = db.TodoItems.Where(b => b.TodoListId == listId).ToList();
            return TodoItems;
        }

        public TodoItem GetTask(int listId, int itemId)
        {
            TodoItem TodoItem = new TodoItem();
            TodoItem = db.TodoItems.Where(b => b.TodoItemId == itemId);
            return TodoItem;
        }
        public TodoItem UpdateTodoItem(int listId, int itemId, TodoItem todoItem)
        {
            todoItem.TodoListId = listId;
            todoItem.TodoItemId = itemId;
            db.TodoItems.Update(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public TodoList AddTodoList(TodoList todoList)
        {
            db.TodoLists.Add(todoList);
            db.SaveChanges();
            return todoList;
        }

        public PlannedDTO GetTodayTasks()//dashboard
        {
            List<NotDoneDTO> list = new List<NotDoneDTO>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select l.todo_list_id, l.title, Count(i.done) from todo_items i right join todo_lists l on l.todo_list_id=i.todo_list_id  where i.done=false group by l.todo_list_id, l.title";
                db.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NotDoneDTO()
                        {
                            TodoListId = reader.GetInt32(0),
                            ListTitle = reader.IsDBNull(1) ? null : reader.GetString(1),
                            CountItems = reader.GetInt32(2)
                        });
                    }
                }
            }
            PlannedDTO result = new PlannedDTO()
            {
                CountOfPlanedForToday = db.TodoItems.Where(b => b.DueDate == DateTime.Today).Count(),
                NotDoneDTO = list
            };
            return result;
        }
        private NotDoneDTO TodayNotDoneDTO(TodoItem todoItem)
        {
            NotDoneDTO todoItemDTO = new NotDoneDTO();
            todoItemDTO.ListTitle = todoItem.TodoList.Title;
            todoItem.TodoList = null;
            todoItemDTO.TodoItem = todoItem;
            return todoItemDTO;
        }
        public List<NotDoneDTO> GetTaskDTO()
        {
            return db.TodoItems
            .Where(b => b.DueDate.Value.Date == DateTime.Today)
            .Include(b => b.TodoList)
            .Select(TodayNotDoneDTO)
            .ToList();
        }
        public List<TodoItem> GetAllTask(bool allStatus)
        {
            if(allStatus)
            {
                return db.TodoItems.Where(b => b.Done == false).ToList();
            }
            else
            {
                return db.TodoItems.ToList();
            }
        }
        
    }
}