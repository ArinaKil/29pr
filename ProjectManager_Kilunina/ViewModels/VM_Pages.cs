using ProjectManager_Kilunina.Classes;

namespace ProjectManager_Kilunina.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_tasks));
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
