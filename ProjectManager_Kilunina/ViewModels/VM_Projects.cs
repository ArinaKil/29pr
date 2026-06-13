using ProjectManager_Kilunina.Classes;
using ProjectManager_Kilunina.Context;
using ProjectManager_Kilunina.Models;
using System.Collections.ObjectModel;

namespace ProjectManager_Kilunina.ViewModels
{
    public class VM_Projects : Notification
    {
        public ProjectsContext projectsContext = new ProjectsContext();
        public ObservableCollection<Projects> Projects { get; set; }
        public VM_Projects() =>
            Projects = new ObservableCollection<Projects>(projectsContext.Projects.OrderBy(x => x.Done));

        public RealyCommand OnAddProject
        {
            get 
            {
                return new RealyCommand(obj => { 
                    Projects NewProject = new Projects()
                    {
                        Name = "Новый проект",
                        Customer = "Не указан",
                        DateEnd = DateTime.Now
                    };
                    Projects.Add(NewProject); 
                    projectsContext.Projects.Add(NewProject); 
                    projectsContext.SaveChanges(); 
                });
            }
        }
    }
}
