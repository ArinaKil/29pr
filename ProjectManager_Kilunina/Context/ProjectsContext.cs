using Microsoft.EntityFrameworkCore;
using ProjectManager_Kilunina.Classes.Database;
using ProjectManager_Kilunina.Models;

namespace ProjectManager_Kilunina.Context
{
    public class ProjectsContext : DbContext
    {
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public ProjectsContext()
        {
            Database.EnsureCreated();
            Projects.Load(); 
            Tasks.Load(); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.connection, Config.version);
    }
}
