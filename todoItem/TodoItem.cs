using System;

namespace TodoItems
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public bool Done { get; set; }
        public DateTime? DueDate { get; set; }

    }
}
//http 127.0.0.1:5000/api/todolist/create title='new title'