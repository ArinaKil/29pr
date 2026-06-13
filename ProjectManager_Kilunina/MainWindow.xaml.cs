using ProjectManager_Kilunina.ViewModels;
using System.Windows;

namespace ProjectManager_Kilunina
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            DataContext = new VM_Pages();
        }
    }
}