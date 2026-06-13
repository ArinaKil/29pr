using ProjectManager_Kilunina.Classes;

namespace ProjectManager_Kilunina.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Projects vm_projects = new VM_Projects();
        public VM_Tasks vm_tasks;
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_projects));
        }
        public RealyCommand OnClose
        {
            get 
            {
                return new RealyCommand(obj => { 
                    MainWindow.init.Close(); 
                });
            }
        }
    }
}
