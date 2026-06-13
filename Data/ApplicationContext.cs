using Microsoft.EntityFrameworkCore;
using ToDoApp_WebApi.Models.Entities;
namespace ToDoApp_WebApi.Data
{
    //public class AppContext : DbContext
    //{
    //    public DbSet<ToDoTask> ToDoTasks => Set<ToDoTask>();
    //    public AppContext() => Database.EnsureCreated();
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlite("Data Source = ToDoTasks.db");
    //    }
    //}

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
