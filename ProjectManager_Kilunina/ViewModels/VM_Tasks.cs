using ProjectManager_Kilunina.Classes;
using ProjectManager_Kilunina.Context;
using ProjectManager_Kilunina.Models;
using System.Collections.ObjectModel;

namespace ProjectManager_Kilunina.ViewModels
{
    public class VM_Tasks : Notification
    {
        public ProjectsContext tasksContext;
        public Projects Project { get; set; }
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks(Projects project, ProjectsContext context)
        {
            Project = project; 
            tasksContext = context; 
            Tasks = new ObservableCollection<Tasks>(
                tasksContext.Tasks.Where(x => x.ProjectId == project.Id).OrderBy(x => x.Done));
        }
        public RealyCommand OnAddTask
        {
            get 
            {
                return new RealyCommand(obj => { 
                    Tasks NewTask = new Tasks()
                    {
                        Name = "Новая задача",
                        Priority = "Средний",
                        Comment = "—",
                        DateExecute = DateTime.Now,
                        ProjectId = Project.Id
                    };
                    Tasks.Add(NewTask); 
                    tasksContext.Tasks.Add(NewTask); 
                    tasksContext.SaveChanges(); 
                });
            }
        }
        public RealyCommand OnBack
        {
            get 
            {
                return new RealyCommand(obj => { 
                    MainWindow.init.frame.Navigate(
                        new View.Main((MainWindow.init.DataContext as VM_Pages).vm_projects));
                });
            }
        }
    }
}
