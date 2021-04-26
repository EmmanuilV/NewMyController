using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoItems.Models
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }



        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

    }
}

