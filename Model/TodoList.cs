using System;
using System.Collections.Generic;

namespace TodoItems
{
    public class TodoList
    {
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public List<TodoItem> TodoItems { get; set; }

    }
}