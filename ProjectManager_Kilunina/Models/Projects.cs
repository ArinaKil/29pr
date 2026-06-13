using ProjectManager_Kilunina.Classes;
using ProjectManager_Kilunina.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager_Kilunina.Models
{
    public class Projects : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value ?? "", "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("Название проекта не должно быть пустым, и не более 100 символов.",
                        "Не корректный ввод значения.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string customer;
        public string Customer
        {
            get { return customer; }
            set
            {
                Match match = Regex.Match(value ?? "", "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("Заказчик не должен быть пустым, и не более 100 символов.",
                        "Не корректный ввод значения.");
                else
                {
                    customer = value;
                    OnPropertyChanged("Customer");
                }
            }
        }
        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                if (value.Date < DateTime.Now.Date)
                    MessageBox.Show("Срок сдачи не может быть меньше текущей даты.",
                        "Не корректный ввод значения.");
                else
                {
                    dateEnd = value;
                    OnPropertyChanged("DateEnd");
                }
            }
        }
        public bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                OnPropertyChanged("Done");
                OnPropertyChanged("StatusText");
            }
        }
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();

        [Schema.NotMapped]
        public List<string> Statuses { get; } = new List<string> { "В работе", "Завершён" };
        [Schema.NotMapped]
        public string StatusText
        {
            get
            {
                if (Done) return "Завершён";
                else return "В работе";
            }
            set
            {
                Done = (value == "Завершён");
            }
        }
        [Schema.NotMapped]
        private bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }
        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnOpen
        {
            get
            {
                return new RealyCommand(obj => {
                    VM_Pages pages = MainWindow.init.DataContext as VM_Pages;
                    pages.vm_tasks = new VM_Tasks(this, pages.vm_projects.projectsContext);
                    MainWindow.init.frame.Navigate(new View.TasksPage(pages.vm_tasks));
                });
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj => {
                    IsEnable = !IsEnable;

                    if (!IsEnable)
                        (MainWindow.init.DataContext as VM_Pages).vm_projects.projectsContext.SaveChanges();
                });
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj => {
                    if (MessageBox.Show("Вы уверены что хотите удалить проект и все его задачи?",
                        "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        VM_Pages pages = MainWindow.init.DataContext as VM_Pages;
                        pages.vm_projects.Projects.Remove(this);
                        pages.vm_projects.projectsContext.Projects.Remove(this);
                        pages.vm_projects.projectsContext.SaveChanges();
                    }
                });
            }
        }
    }
}
