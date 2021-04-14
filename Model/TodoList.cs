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
//http 127.0.0.1:5000/api/todolist/create title='new title'