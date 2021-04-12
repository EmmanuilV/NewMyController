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
        public TodoItem AddTodoItem(TodoItem todoItem)
        {
            db.TodoItems.Add(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public TodoItem DeleteTodoItem(int id)
        {
            var todoItem = db.TodoItems
            .Where(b => b.Id == id)
            .Single();
            db.TodoItems.Remove(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public List<TodoItem> ReadAllTodoItems()
        {
            List<TodoItem> TodoItems = new List<TodoItem>();

            TodoItems = db.TodoItems.ToList();

            return TodoItems;
        }
        public TodoItem UpdateTodoItem(TodoItem todoItem)
        {
            db.TodoItems.Update(todoItem);
            db.SaveChanges();
            return todoItem;
        }

    }
}