using Microsoft.EntityFrameworkCore;
using ProjectManager_Kilunina.Classes.Database;
using ProjectManager_Kilunina.Models;

namespace ProjectManager_Kilunina.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load(); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.connection, Config.version);
    }
}
