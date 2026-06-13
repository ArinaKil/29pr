using System.Windows.Controls;

namespace ProjectManager_Kilunina.View
{
    public partial class TasksPage : Page
    {
        public TasksPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}
