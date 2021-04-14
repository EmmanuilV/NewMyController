using System;

namespace TodoItems
{
    public class NotDoneDTO
    {
        public int TodoListId { get; set; }
        public string ListTitle { get; set; }
        public int CountItems { get; set; }
        public TodoItem TodoItem { get; set; }

    }
}