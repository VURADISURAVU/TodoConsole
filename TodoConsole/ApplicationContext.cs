using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoConsole
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Todo> TodoList { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COMPUTER;Initial Catalog=idk;Integrated Security=True;Pooling=False");
        }
    }
}
