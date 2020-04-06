using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Todos
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }

    public class TodosDBContext : DbContext
    {
        public TodosDBContext(DbContextOptions<TodosDBContext> options) : base(options) { }
        public DbSet<Todos> Todo { get; set; }
    }
}
