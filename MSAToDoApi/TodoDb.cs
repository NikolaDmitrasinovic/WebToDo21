﻿using Microsoft.EntityFrameworkCore;

namespace MSAToDoApi
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; }
    }
}
